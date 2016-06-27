using Spectrum.SharedKernel.Authorisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data;
using EWS.Domain.Data.Commands;
using EWS.Domain.Data.Queries;
using EWS.Domain.DomainServices;
using EWS.Domain.Model;
using EWS.Domain.Core;

namespace EWS.Application.Services
{
    public class QuoteService
    {
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        private ICurrentUserFactory _currentUserFactory;

        public QuoteService(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, ICurrentUserFactory currentUserFactory)
        {
            if (currentUserFactory == null) throw new ArgumentNullException("CurrentUserFactory cannot be null");
            if (commandProcessor == null) throw new ArgumentNullException("Command Processor cannot be null");
            if (queryProcessor == null) throw new ArgumentNullException("Query Processor cannot be null");

            _currentUserFactory = currentUserFactory;
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        
        public T GetModel<T>(int EntityID)
        {
            T model;

            if (typeof(T) == typeof(EnterEquipmentQuote))
            {
                model = (T)Convert.ChangeType(GetEquipmentQuote_Model(EntityID), typeof(T));
            }
            else if (typeof(T) == typeof(EnterCurrentQuote))
            {
                model = (T)Convert.ChangeType(GetCurrentQuote_Model(EntityID), typeof(T));
            }
            else if (typeof(T) == typeof(Quote))
            {
                model = (T)Convert.ChangeType(GetQuote_Model(EntityID), typeof(T));
            }
            else if (typeof(T) == typeof(Customer))
            {
                model = (T)Convert.ChangeType(GetCustomer_Model(EntityID), typeof(T));
            }
            else
                throw new InvalidOperationException("Unhandled type: " + typeof(T).ToString() + " in GetModel<T>(int)");

            return model;
        }

        public T GetModel<T>(string Ref)
        {
            T model;

            if (typeof(T) == typeof(EnterEquipmentQuote))
            {
                model = (T)Convert.ChangeType(GetEquipmentQuote_Model(Ref), typeof(T));
            }
            else if (typeof(T) == typeof(EnterCurrentQuote))
            {
                model = (T)Convert.ChangeType(GetCurrentQuote_Model(Ref), typeof(T));
            }
            else
                throw new InvalidOperationException("Unhandled type: " + typeof(T).ToString() + " in GetModel<T>(string)");

            return model;
        }

        
        private Customer GetCustomer_Model(int CustomerID)
        {
            CustomerQuery query = new CustomerQuery() { ID = CustomerID };
            Domain.Data.DataModel.Customer customer = _queryProcessor.Execute(query);

            if (customer == null)
                return null;
            else
                return new Customer()
                {
                    Id = CustomerID,
                    CustomerName = customer.CustomerNameFriendly,
                    Locality = customer.CustomerLocality.CustomerLocalityName,
                    RegistrationNo = customer.RegistrationNo
                };

        }   
        
        public IEnumerable<EWS.Domain.Data.DataModel.ContractTerm> GetContractTerms()
        {
            ContractTermsQuery qry = new ContractTermsQuery();
            return _queryProcessor.Execute(qry);
        }

        public IEnumerable<SourceQuote> GetSourceQuotes(string QuoteRef)
        {  
            if (string.IsNullOrEmpty(QuoteRef))
            {
                return new SourceQuote[] { };   // empty list
            }
            else
            { 
                SourceQuotesQuery query = new Domain.Data.Queries.SourceQuotesQuery() { QuoteRef = QuoteRef };
                IEnumerable<SourceQuote> founditems = _queryProcessor.Execute<IEnumerable<SourceQuote>>(query);
                foreach (SourceQuote item in founditems)
                {
                    if (item.QuoteRef == QuoteRef) item.Selected = true;
                }
                return founditems;
            }
        }

        public SourceQuote GetSourceQuote(string QuoteRef)
        {
            if (string.IsNullOrEmpty(QuoteRef))
                return null;
            else
            {
                SourceQuoteQuery query = new Domain.Data.Queries.SourceQuoteQuery() { QuoteRef = QuoteRef };
                SourceQuote founditem = _queryProcessor.Execute<SourceQuote>(query);

                return founditem;
            }

        }


        private EWS.Domain.Data.DataModel.Quote GetExistingQuote(string QuoteRef)
        {
            QuoteQuery query = new Domain.Data.Queries.QuoteQuery() { QuoteRef = QuoteRef };
            EWS.Domain.Data.DataModel.Quote founditem = _queryProcessor.Execute<EWS.Domain.Data.DataModel.Quote>(query);

            return founditem;
        }

        private EWS.Domain.Data.DataModel.Quote GetExistingQuote(int ContractID)
        {
            QuoteQuery query = new Domain.Data.Queries.QuoteQuery() { BaseContractID = ContractID };
            EWS.Domain.Data.DataModel.Quote founditem = _queryProcessor.Execute<EWS.Domain.Data.DataModel.Quote>(query);

            return founditem;
        }


        public EWS.Domain.Data.DataModel.Contract GetContract(int ContractID)
        {          
                ContractQuery query = new Domain.Data.Queries.ContractQuery() { ID = ContractID };
                EWS.Domain.Data.DataModel.Contract founditem = _queryProcessor.Execute(query);

                return founditem;
        }

        public List<EWS.Domain.Data.DataModel.ContractItem> GetContractItems(int ContractID)
        {
            ContractItemsQuery query = new Domain.Data.Queries.ContractItemsQuery() { ContractID = ContractID };
            IEnumerable<EWS.Domain.Data.DataModel.ContractItem> founditems = _queryProcessor.Execute(query);
            return founditems.ToList();
        }

        public List<EWS.Domain.Data.DataModel.Contract> GetContracts(string Keyword)
        {
            if (string.IsNullOrEmpty(Keyword))
            {
                return new List<EWS.Domain.Data.DataModel.Contract>();
            }
            else
            {
                ContractsQuery query = new Domain.Data.Queries.ContractsQuery() { Keyword = Keyword };
                IEnumerable<EWS.Domain.Data.DataModel.Contract> founditems = _queryProcessor.Execute(query);
             
                return founditems.ToList();
            }
        }


        List<EWS.Domain.Model.QuoteCalculation> GetNewEquipmentContractCalculationModels(decimal BasePrice)
        {
            ContractTypesQuery query = new ContractTypesQuery();

            IEnumerable<Domain.Data.DataModel.ContractType> contractypes = _queryProcessor.Execute(query);

            List<QuoteCalculation> models = new List<QuoteCalculation>();

            foreach (Domain.Data.DataModel.ContractType contracttype in contractypes)
            {
                QuoteCalculation model = new QuoteCalculation(0, contracttype.ID, contracttype.ContractTypeName, BasePrice, BasePrice, EWS.Domain.Data.DataModel.ContractTerm.DefaultNoOfMonths);
                //ContractTermQuery ctqry = new ContractTermQuery( ) { NoOfMonths = EWS.Domain.Data.DataModel.ContractTerm.DefaultNoOfMonths};
                //model.ContractTerm = _queryProcessor.Execute(ctqry);
                models.Add(model);
            }

            return models;
        }

        List<QuoteCalculation> GetNewContractCalculationModels(decimal BasePrice)
        {
            ContractTypesQuery query = new ContractTypesQuery();

            IEnumerable<Domain.Data.DataModel.ContractType> contractypes = _queryProcessor.Execute(query);

            List<QuoteCalculation> models = new List<QuoteCalculation>();

            foreach (Domain.Data.DataModel.ContractType contracttype in contractypes)
            {
                QuoteCalculation model = new QuoteCalculation(0, contracttype.ID, contracttype.ContractTypeName, 0, BasePrice, EWS.Domain.Data.DataModel.ContractTerm.DefaultNoOfMonths);
                //ContractTermQuery ctqry = new ContractTermQuery( ) { NoOfMonths = EWS.Domain.Data.DataModel.ContractTerm.DefaultNoOfMonths};
                //model.ContractTerm = _queryProcessor.Execute(ctqry);
                models.Add(model);
            }

            return models;
        }


        public List<QuoteCalculation> GetModelList(int QuoteID)
        {
            List<QuoteCalculation> modellist = new List<QuoteCalculation>();

            QuoteCalculationsQuery qry = new QuoteCalculationsQuery() { QuoteID = QuoteID};
            IEnumerable<EWS.Domain.Data.DataModel.QuoteCalculation> entitylist = _queryProcessor.Execute(qry);

            foreach (EWS.Domain.Data.DataModel.QuoteCalculation entity in entitylist)
            {
                QuoteCalculation model = new QuoteCalculation()
                {
                    ContractTypeID = entity.ContractTypeID,
                    ContractType = entity.ContractType.ContractTypeName,
                    BasePrice = entity.SellingPricePercAmount / (entity.SellingPricePerc / 100),
                    SellingPricePerc = entity.SellingPricePerc,                   
                    ROEPortion = entity.ROEPortion,
                    ZARPortion = entity.ZARPortion,
                    ROEPortionAmount = entity.ROEPortionAmount,
                    ZARPortionAmount = entity.ZARPortionAmount
                };

                //ContractTermQuery ctqry = new ContractTermQuery() { NoOfMonths = entity.ContractTerm };
                //EWS.Domain.Data.DataModel.ContractTerm contractterm = _queryProcessor.Execute(ctqry);
                //model.ContractTerm = contractterm;

                modellist.Add(model);
            }

            return modellist;
        }


        private EnterEquipmentQuote GetEquipmentQuote_Model(int QuoteID)
        {
            if (QuoteID <= 0)
                return null;
            else
            {
                QuoteQuery query = new Domain.Data.Queries.QuoteQuery() { ID = QuoteID };
                EWS.Domain.Data.DataModel.Quote entity = _queryProcessor.Execute<EWS.Domain.Data.DataModel.Quote>(query);

                return GetEquipmentQuote_Model(entity);
            }
        }

        private EnterEquipmentQuote GetEquipmentQuote_Model(EWS.Domain.Data.DataModel.Quote entity)
        {
            EnterEquipmentQuote model = new EnterEquipmentQuote();
            model.QuoteID = entity.ID;
            model.QuoteRef = entity.QuoteRef;
            model.TenderNumber = entity.TenderNo;
            model.VAT = entity.VAT;
            model.SellingPriceExclVAT = entity.SellingPrice;
            model.SellingPriceInclVAT = Math.Round(entity.SellingPrice * Convert.ToDecimal(entity.VAT / 100 + 1), 2);
            model.NoOfMonths = entity.ContractTerm;

            model.Customer = GetCustomer_Model(entity.CustomerID);

            DeviceQuery dqry = new Domain.Data.Queries.DeviceQuery() { DeviceID = entity.DeviceID };
            model.Device = _queryProcessor.Execute(dqry);

            model.ExchangeRate = new ExchangeRate()
            {
                Rate = entity.ROE,
                Date = entity.ROEDate
            };

            model.ContractCalculations = GetNewEquipmentContractCalculationModels(model.SellingPriceExclVAT);
            UpdateModelFromSavedValues(model.ContractCalculations, model.QuoteID);


            return model;
        }   

        private EnterEquipmentQuote GetEquipmentQuote_Model(string QuoteRef)
        {
            if (string.IsNullOrEmpty(QuoteRef))
                return null;
            else
            {
                EWS.Domain.Data.DataModel.Quote quote = GetExistingQuote(QuoteRef);
                if (quote != null)
                    return GetEquipmentQuote_Model(quote);
                else
                {
                    Domain.Model.SourceQuote sourcequote = GetSourceQuote(QuoteRef);
                    if (sourcequote == null)
                        return null;
                    else
                    {
                        EnterEquipmentQuote model = new EnterEquipmentQuote();

                        model.QuoteRef = QuoteRef;

                        DeviceQuery query = new Domain.Data.Queries.DeviceQuery() { DeviceID = sourcequote.DeviceID };
                        model.Device = _queryProcessor.Execute(query);

                        model.TenderNumber = sourcequote.TenderNumber;
                        model.VAT = sourcequote.VAT;
                        model.SellingPriceExclVAT = sourcequote.SellingPriceInclVAT / Convert.ToDecimal(1 + sourcequote.VAT / 100);
                        model.SellingPriceInclVAT = sourcequote.SellingPriceInclVAT;

                        model.ContractCalculations = GetNewEquipmentContractCalculationModels(model.SellingPriceExclVAT);


                        if (quote == null)   // fill in from source quote:
                        {
                            // Exchange Rate
                            CurrencyQuery cquery = new CurrencyQuery() { ID = "USD" };
                            Domain.Data.DataModel.Currency usd = _queryProcessor.Execute(cquery);

                            model.ExchangeRate = new ExchangeRate()
                            {
                                Rate = Convert.ToDecimal(usd.DefaultRateOfExchange),
                                Date = DateTime.Today
                            };
                        }
                        return model;
                    }
                }
            }
        } //GetEquipmentQuote_Model


        private EnterCurrentQuote GetCurrentQuote_Model(int QuoteID)
        {
            if (QuoteID <= 0)
                return null;
            else
            {
                QuoteQuery query = new Domain.Data.Queries.QuoteQuery() { ID = QuoteID };
                EWS.Domain.Data.DataModel.Quote entity = _queryProcessor.Execute<EWS.Domain.Data.DataModel.Quote>(query);

                return GetCurrentQuote_Model(entity);
            }
        }

        private EnterCurrentQuote GetCurrentQuote_Model(EWS.Domain.Data.DataModel.Quote entity)
        {
            EnterCurrentQuote model = new EnterCurrentQuote();
            model.QuoteID = entity.ID;
            model.TenderNumber = entity.TenderNo;
            model.VAT = entity.VAT;
            model.SellingPriceExclVAT = entity.SellingPrice;
            model.SellingPriceInclVAT = Math.Round(entity.SellingPrice * Convert.ToDecimal(entity.VAT / 100 + 1), 2);
            model.NoOfMonths = entity.ContractTerm;

            model.Customer = GetCustomer_Model(entity.CustomerID);

            DeviceQuery dqry = new Domain.Data.Queries.DeviceQuery() { DeviceID = entity.DeviceID };
            model.Device = _queryProcessor.Execute(dqry);

            model.ExchangeRate = new ExchangeRate()
            {
                Rate = entity.ROE,
                Date = entity.ROEDate
            };

            model.ContractCalculations = GetNewContractCalculationModels(model.SellingPriceExclVAT);
            UpdateModelFromSavedValues(model.ContractCalculations, model.QuoteID);

            return model;
        }

        private EnterCurrentQuote GetCurrentQuote_Model(string ContractID)
        {
            if (string.IsNullOrEmpty(ContractID))
                return null;
            else
            {
                int contractID =Convert.ToInt32( ContractID);
                EWS.Domain.Data.DataModel.Quote quote = GetExistingQuote(contractID);
                if (quote != null)
                    return GetCurrentQuote_Model(quote);
                else
                {
                    EWS.Domain.Data.DataModel.Contract sourcecontract = GetContract(contractID);
                    if (sourcecontract == null)
                        return null;
                    else
                    {
                        EnterCurrentQuote model = new EnterCurrentQuote();


                        DeviceQuery query = new Domain.Data.Queries.DeviceQuery() { DeviceID = sourcecontract.DeviceID };
                        model.Device = _queryProcessor.Execute(query);

                        model.TenderNumber = sourcecontract.TenderNo;
                        model.VAT = sourcecontract.VAT;
                        model.SellingPriceExclVAT = 0;
                        model.SellingPriceInclVAT = 0;


                        List<EWS.Domain.Data.DataModel.ContractItem> contractitems = GetContractItems(contractID);
                        model.ContractCalculations = new List<QuoteCalculation>();
                        foreach (EWS.Domain.Data.DataModel.ContractItem contractitem in contractitems)
                        {
                            model.ContractCalculations.Add(new QuoteCalculation()
                            {
                                Selected = true,
                                BasePrice = contractitem.BasePrice,
                                ContractTypeID = contractitem.ContractTypeID,
                                ContractType = contractitem.ContractType.ContractTypeName,
                                ROEPortion = contractitem.ROEPortion,
                                ROEPortionAmount = contractitem.ROEPortionAmount,
                                ZARPortion = contractitem.ZARPortion,
                                ZARPortionAmount = contractitem.ZARPortionAmount
                            });
                        }

                        CustomerQuery customerquery = new CustomerQuery() { ID = sourcecontract.CustomerID };
                        Domain.Data.DataModel.Customer customer = _queryProcessor.Execute(customerquery);

                        model.Customer = new Customer()
                        {
                            Id = sourcecontract.CustomerID,
                            CustomerName = customer.CustomerNameFriendly,
                            Locality = customer.CustomerLocality.CustomerLocalityName,
                            RegistrationNo = customer.RegistrationNo
                        };

                        model.ExchangeRate = new ExchangeRate()
                        {
                            Rate = sourcecontract.ROE,
                            Date = sourcecontract.ROEDate
                        };
                        
                        return model;
                    }
                }
            }
        } //GetCurrentQuote_Model



        private EWS.Domain.Model.Quote GetQuote_Model(int QuoteID)
        {
            if (QuoteID <= 0)
                return null;
            else
            {
                QuoteQuery query = new Domain.Data.Queries.QuoteQuery() { ID = QuoteID };
                EWS.Domain.Data.DataModel.Quote entity = _queryProcessor.Execute<EWS.Domain.Data.DataModel.Quote>(query);

                return GetQuote_Model(entity);
            }
        }

        private EWS.Domain.Model.Quote GetQuote_Model(EWS.Domain.Data.DataModel.Quote entity)
        {
            EWS.Domain.Model.Quote model = new EWS.Domain.Model.Quote();
            model.QuoteID = entity.ID;
            model.QuoteRef = entity.QuoteRef;
            model.ContractID = entity.BaseContractID;
            model.TenderNumber = entity.TenderNo;
            model.VAT = entity.VAT;
            model.SellingPriceExclVAT = entity.SellingPrice;
            model.SellingPriceInclVAT = Math.Round(entity.SellingPrice * Convert.ToDecimal(entity.VAT / 100 + 1), 2);
            model.NoOfMonths = entity.ContractTerm;

            model.Customer = GetCustomer_Model(entity.CustomerID);

            DeviceQuery dqry = new Domain.Data.Queries.DeviceQuery() { DeviceID = entity.DeviceID };
            model.Device = _queryProcessor.Execute(dqry);

            model.ExchangeRate = new ExchangeRate()
            {
                Rate = entity.ROE,
                Date = entity.ROEDate
            };

            QuoteCalculationsQuery qcqry = new QuoteCalculationsQuery() { QuoteID = entity.ID };
            IEnumerable<Domain.Data.DataModel.QuoteCalculation> listofQuoteCalcs = _queryProcessor.Execute(qcqry);

            model.ContractCalculations = new List<QuoteCalculation>();

            foreach(Domain.Data.DataModel.QuoteCalculation calc in listofQuoteCalcs)
            {
                QuoteCalculation calcmodel = new QuoteCalculation();
                MapEntityToModel(calc, calcmodel);
                model.ContractCalculations.Add(calcmodel);

                QuoteCalculationItem[] years = GetQuoteCalculationItemsStructure(calc, (short)(model.NoOfMonths / 12), model.StartDate);
                calcmodel.QuoteCalculationItems = Recalculate(calcmodel, years, model.StartDate);
       
           
            }

        
            return model;
        }

        public QuoteCalculationItem[] Recalculate(QuoteCalculation calcmodel, QuoteCalculationItem[] CalculationItems, DateTime? StartDate)
        {
            EWS.Domain.Events.Quoting helper = new EWS.Domain.Events.Quoting()
            {
                //SellingPrice = entity.SellingPrice,
                //RateOfExchange = entity.ROE,
                //RateOfExchangeDate = entity.ROEDate,
                //SellingPricePerc = calcmodel.SellingPricePerc,
                //ROEPortion = calcmodel.ROEPortion,
                ROEPortionAmount = calcmodel.ROEPortionAmount,
                ZARPortionAmount = calcmodel.ZARPortionAmount,
                StartDate = StartDate
            };

            helper.ApplyCalculationLogic(ref CalculationItems);
            return CalculationItems;
        }


        private void UpdateModelFromSavedValues(List<QuoteCalculation> models, int QuoteID)
        {

            QuoteCalculationsQuery query = new QuoteCalculationsQuery() { QuoteID = QuoteID };
            IEnumerable<Domain.Data.DataModel.QuoteCalculation> calcs = _queryProcessor.Execute(query);

            foreach (QuoteCalculation model in models)
            {
                Domain.Data.DataModel.QuoteCalculation calc = calcs.FirstOrDefault(c => c.ContractTypeID == model.ContractTypeID);
                if (calc == null)
                    model.Selected = false;
                else
                {
                    model.Selected = true;
                    MapEntityToModel(calc, model);
                }
            }

        }

        private void UpdateModelFromSavedValues(IEnumerable<QuoteCalculationItem> models, int QuoteCalculationID)
        {

            QuoteCalculationItemsQuery query = new QuoteCalculationItemsQuery() { QuoteCalculationID = QuoteCalculationID };
            IEnumerable<Domain.Data.DataModel.QuoteCalculationItem> calcs = _queryProcessor.Execute(query);

            foreach (QuoteCalculationItem model in models)
            {
                Domain.Data.DataModel.QuoteCalculationItem item = calcs.FirstOrDefault(c => c.YearNo == model.YearNo);
                if (item != null)
                {
                    MapEntityToModel(item, model);
                }
            }

        }


        private static void MapEntityToModel(Domain.Data.DataModel.QuoteCalculation calc, QuoteCalculation model )
        {
            model.Selected = true;

            model.ContractCalculationID = calc.ID;
            model.ContractTypeID = calc.ContractTypeID;
            model.ROEPortion = calc.ROEPortion;
            model.ROEPortionAmount = calc.ROEPortionAmount;
            model.ZARPortion = calc.ZARPortion;
            model.ZARPortionAmount = calc.ZARPortionAmount;

            //model.BasePrice = calc.SellingPricePercAmount * (1 + calc.SellingPricePercAmount / 100);
            model.BasePrice = calc.BasePrice;
            model.SellingPricePerc = calc.SellingPricePerc;

            model.ContractType = calc.ContractType.ContractTypeName;
        }

        private static void MapEntityToModel(Domain.Data.DataModel.QuoteCalculationItem item, QuoteCalculationItem model)
        {          
            model.ID = item.ID;
            model.YearNo = item.YearNo ;
            model.ROEPortion = item.ROEPortionAmount;
            model.ZARPortion = item.ZARPortionAmount;
            model.UseNewROE = (item.ROE == model.NewROE) ;
        
            model.Increment = item.IncrPerc;
            model.AmountExclVAT = item.AmountExclVAT;
            model.AmountInclVAT = item.AmountInclVAT;
            
        }


        public string SaveQuote(EnterEquipmentQuote model)
        {

            try
            {

                QuoteSaveCommand cmd1 = new QuoteSaveCommand()
                {
                    ID = model.QuoteID,
                    CustomerID = model.Customer.Id,
                    DeviceID = model.Device.Id,
                    TenderNo = model.TenderNumber,
                    QuoteRef = model.QuoteRef,
                    SellingPrice = model.SellingPriceExclVAT,                  
                    ROE = model.ExchangeRate.Rate,
                    ROEDate = model.ExchangeRate.Date,
                    VAT = model.VAT,
                    ContractTerm = model.NoOfMonths,
                    Deleted = false
                };
                _commandProcessor.Execute(cmd1);

                model.QuoteID = cmd1.ID;

                SaveQuoteCalculation(model.ContractCalculations, model.QuoteID);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Save was unsuccessful: " + ex.Message;
            }

        }

        public string SaveQuote(EnterCurrentQuote model)
        {

            try
            {

                QuoteSaveCommand cmd1 = new QuoteSaveCommand()
                {
                    ID = model.QuoteID,
                    CustomerID = model.Customer.Id,
                    DeviceID = model.Device.Id,
                    TenderNo = model.TenderNumber,
                    BaseContractID = model.ContractID,
                    SellingPrice = model.SellingPriceExclVAT,
                    ROE = model.ExchangeRate.Rate,
                    ROEDate = model.ExchangeRate.Date,
                    VAT = model.VAT,
                    ContractTerm = model.NoOfMonths,
                    Deleted = false
                };
                _commandProcessor.Execute(cmd1);

                model.QuoteID = cmd1.ID;

                SaveQuoteCalculation(model.ContractCalculations, model.QuoteID);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Save was unsuccessful: " + ex.Message;
            }

        }

        public string SaveQuote(Quote model)
        {

            try
            {
                QuoteSaveCommand cmd1 = new QuoteSaveCommand()
                {
                    ID = model.QuoteID,
                    CustomerID = model.Customer.Id,
                    DeviceID = model.Device.Id,
                    QuoteRef = model.QuoteRef,
                    TenderNo = model.TenderNumber,
                    BaseContractID = model.ContractID,
                    SellingPrice = model.SellingPriceExclVAT,
                    ROE = model.ExchangeRate.Rate,
                    ROEDate = model.ExchangeRate.Date,
                    VAT = model.VAT,
                    Deleted = false
                };
                _commandProcessor.Execute(cmd1);

                model.QuoteID = cmd1.ID;

                SaveQuoteCalculation(model.ContractCalculations, model.QuoteID);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Save was unsuccessful: " + ex.Message;
            }

        }


        private void SaveQuoteCalculation(IEnumerable<QuoteCalculation> ContractCalculations, int QuoteID)
        {
            foreach (QuoteCalculation calc in ContractCalculations)
            {
                if (calc.Selected)
                {
                    QuoteCalculationSaveCommand cmd2 = new QuoteCalculationSaveCommand()
                    {
                        ID = calc.ContractCalculationID,
                        QuoteID = QuoteID,
                        ContractTypeID = calc.ContractTypeID,
                        ROEPortion = calc.ROEPortion,
                        ROEPortionAmount = calc.ROEPortionAmount,
                        SellingPricePerc = calc.SellingPricePerc,
                        BasePrice = calc.BasePrice,
                        ZARPortion = calc.ZARPortion,
                        ZARPortionAmount = calc.ZARPortionAmount
                    };

                    _commandProcessor.Execute(cmd2);

                    SaveYears(cmd2.ID, calc.QuoteCalculationItems);
                }
            }
        } //SaveQuoteCalculation

        private void SaveYears(int QuoteCalculationID, IEnumerable<QuoteCalculationItem> years)
        {
            if (years != null)
            { 
                foreach(QuoteCalculationItem yr in years)
                {
                    QuoteCalculationItemSaveCommand cmd = new QuoteCalculationItemSaveCommand()
                        {   ID = yr.ID,
                            IncrPerc = yr.Increment,
                            QuoteCalculationID = QuoteCalculationID,
                            ROE = yr.UseNewROE? yr.NewROE : yr.TOPSROE,
                            ROEPortionAmount = yr.ROEPortion,
                            YearNo = yr.YearNo,
                            ZARPortionAmount = yr.ZARPortion,
                            AmountExclVAT = yr.AmountExclVAT,
                            AmountInclVAT = yr.AmountInclVAT
                        };

                    _commandProcessor.Execute(cmd);                  
                }
            }
        }


        private EWS.Domain.Model.QuoteCalculationItem[] GetQuoteCalculationItemsStructure(Domain.Data.DataModel.QuoteCalculation calc, short NoOfYears, DateTime? StartDate = null)
        {
            QuoteCalculationItem[] models = new QuoteCalculationItem[NoOfYears];

            // new/old ROE and VAT values needed .........................................
            decimal oldROE;
            decimal newROE;
            float VAT;

 
            QuoteQuery quotequery = new QuoteQuery(){ID = calc.QuoteID};
            EWS.Domain.Data.DataModel.Quote quoteEntity = _queryProcessor.Execute(quotequery);
            newROE = quoteEntity.ROE;

            if (!string.IsNullOrEmpty(quoteEntity.QuoteRef))
            {
                SourceQuoteQuery query = new SourceQuoteQuery() {QuoteRef = quoteEntity.QuoteRef};
                SourceQuote entity = _queryProcessor.Execute(query);
                oldROE = entity.ROE;
                VAT = entity.VAT;
            }
            else
            {
                ContractQuery query = new ContractQuery() {ID = quoteEntity.BaseContractID.Value};
                EWS.Domain.Data.DataModel.Contract entity = _queryProcessor.Execute(query);
                oldROE = entity.ROE;
                VAT = entity.VAT;
            }

            // Currently Saved values ....................................................
            QuoteCalculationItemsQuery qury = new QuoteCalculationItemsQuery() { QuoteCalculationID = calc.ID };
            IEnumerable<Domain.Data.DataModel.QuoteCalculationItem> calcs = _queryProcessor.Execute(qury);

            // Setup the structure .......................................................
            for (byte i = 0; i < NoOfYears; i++)
            {
                byte yearno = (byte)(i + 1);
                models[i] = new QuoteCalculationItem() {YearNo = yearno, 
                                                        NewROE = newROE, TOPSROE = oldROE, VAT = VAT,
                                                        UseNewROE = true, 
                                                        Increment = (i == 0 ? 0 : EWS.Domain.Defaults.AnnualIncrement) };

                if (StartDate.HasValue)
                {
                    models[i].StartDate = StartDate.Value.AddYears(i);
                    models[i].EndDate = StartDate.Value.AddYears(yearno).AddDays(-1);
                }

                Domain.Data.DataModel.QuoteCalculationItem item = calcs.FirstOrDefault(c => c.YearNo == yearno);
                if (item != null)
                {
                    models[i].ID = item.ID;
                    models[i].Increment = item.IncrPerc;
                    models[i].UseNewROE = (item.ROE == newROE);
                }
               
            }



            return models;
        }

    } //class
} //namespace
