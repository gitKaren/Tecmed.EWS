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



        public EquipmentQuoteStep1 GetModel(string QuoteRef)
        {
            EquipmentQuoteStep1 model = null;
            EWS.Domain.Data.DataModel.Quote quote = GetExistingQuote(QuoteRef);
            if (quote == null)   // new:
            {
                Domain.Model.SourceQuote sourcequote = GetSourceQuote(QuoteRef);

                if (sourcequote != null)
                {
                    model = new EquipmentQuoteStep1();
                    model.QuoteRef = QuoteRef;

                    DeviceQuery query = new Domain.Data.Queries.DeviceQuery() { DeviceID = sourcequote.DeviceID };
                    model.Device = _queryProcessor.Execute(query);

                    model.TenderNumber = DateTime.Today.Year.ToString() + "/" + model.Device.Room.PadLeft(3, '0') + "/" + QuoteRef;
                    model.VAT = sourcequote.VAT;
                    model.EquipmentSellingPriceExclVAT = sourcequote.SellingPriceInclVAT / Convert.ToDecimal(1 + sourcequote.VAT/100);
                    model.EquipmentSellingPriceInclVAT = sourcequote.SellingPriceInclVAT;

                    // Exchange Rate
                    CurrencyQuery cquery = new CurrencyQuery() { ID = "USD" };
                    Domain.Data.DataModel.Currency usd = _queryProcessor.Execute(cquery);

                    model.ExchangeRate = new ExchangeRate()
                    {
                        Rate = Convert.ToDecimal(usd.DefaultRateOfExchange),
                        Date = DateTime.Today
                    };


                    model.ContractCalculationParameters = GetNewContractCalculationModels(model.EquipmentSellingPriceExclVAT);


                    return model;
                }
              
            } 
            else
            {
                model = new EquipmentQuoteStep1();
                model.QuoteRef = QuoteRef;
                model.QuoteID = quote.ID;

                DeviceQuery query = new Domain.Data.Queries.DeviceQuery() { DeviceID = quote.DeviceID };
                model.Device = _queryProcessor.Execute(query);

                model.TenderNumber = DateTime.Today.Year.ToString() + "/" + model.Device.Room.PadLeft(3, '0') + "/" + QuoteRef;
                model.VAT = quote.VAT;
                model.EquipmentSellingPriceExclVAT = quote.SellingPrice;
                model.EquipmentSellingPriceInclVAT = quote.SellingPrice * Convert.ToDecimal(1 + quote.VAT / 100);

                model.ExchangeRate = new ExchangeRate()
                {
                    Rate = quote.ROE,
                    Date = quote.ROEDate
                };


                model.ContractCalculationParameters = GetNewContractCalculationModels(model.EquipmentSellingPriceExclVAT);
                UpdateCalculationFromSavedValues(model.ContractCalculationParameters, model.QuoteID);
               
            }

            return model;
          
        }


        List<ContractCalculation> GetNewContractCalculationModels(decimal BasePrice)
        {
            ContractTypesQuery query = new ContractTypesQuery();

            IEnumerable<Domain.Data.DataModel.ContractType> contractypes = _queryProcessor.Execute(query);

            List<ContractCalculation> models = new List<ContractCalculation>();

            foreach (Domain.Data.DataModel.ContractType contracttype in contractypes)
            {
                models.Add(new ContractCalculation(0, contracttype.ID, contracttype.ContractTypeName, BasePrice));
            }

            return models;
        }

        void UpdateCalculationFromSavedValues(List<ContractCalculation> models, int QuoteID)
        {
           
            QuoteCalculationsQuery query = new QuoteCalculationsQuery() { QuoteID = QuoteID };
            IEnumerable<Domain.Data.DataModel.QuoteCalculation> calcs = _queryProcessor.Execute(query);

            foreach (ContractCalculation model in models)
            {
                Domain.Data.DataModel.QuoteCalculation calc = calcs.FirstOrDefault(c => c.ContractTypeID == model.ContractTypeID);
                if (calc == null)
                    model.Selected = false;
                else
                {
                    model.ContractCalculationID = calc.ID; 
                    model.ROEPortion = calc.ROEPortion;
                    model.ROEPortionAmount = calc.ROEPortionAmount;
                    model.ZARPortion = calc.ZARPortion;
                    model.ZARPortionAmount = calc.ZARPortionAmount;
                    model.Selected = true;
                    model.SellingPrice = calc.SellingPricePercAmount  * (1 + calc.SellingPricePercAmount/100);
                    model.SellingPricePerc = calc.SellingPricePerc;
                    model.SellingPricePercAmount = calc.SellingPricePercAmount;
                }
            }

        }

        public string SaveQuote(EquipmentQuoteStep1 model)
        {
            //if (AuthCheck.NewCheck().MustBeInRole("Dev").IsNotSatisfiedBy(_currentUserFactory.GetCurrentUser()))
            //{
            //    throw new UserNotAuthorisedException();
            //}
            try
            {

                QuoteSaveCommand cmd1 = new QuoteSaveCommand()
                {
                    ID = model.QuoteID,
                    CustomerID = model.CustomerID,
                    DeviceID = model.Device.Id,
                    TenderNo = model.TenderNumber,
                    QuoteRef = model.QuoteRef,
                    SellingPrice = model.EquipmentSellingPriceExclVAT,
                    ROE = model.ExchangeRate.Rate,
                    ROEDate = model.ExchangeRate.Date,
                    VAT = model.VAT,
                    Deleted = false
                };
                _commandProcessor.Execute(cmd1);

                model.QuoteID = cmd1.ID;

                foreach (ContractCalculation calc in model.ContractCalculationParameters)
                {
                    if (calc.Selected)
                    {
                        QuoteCalculationSaveCommand cmd2 = new QuoteCalculationSaveCommand()
                        {
                            ID = calc.ContractCalculationID,
                            QuoteID = cmd1.ID,
                            ContractTypeID = calc.ContractTypeID,
                            ROEPortion = calc.ROEPortion,
                            ROEPortionAmount = calc.ROEPortionAmount,
                            SellingPricePerc = calc.SellingPricePerc,
                            SellingPricePercAmount = calc.SellingPricePercAmount,
                            ZARPortion = calc.ZARPortion,
                            ZARPortionAmount = calc.ZARPortionAmount
                        };

                        _commandProcessor.Execute(cmd2);
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Save was unsuccessful: " + ex.Message;
            }

        }

        public EquipmentQuote GetModel(int QuoteID)
        {
            if (QuoteID <= 0)
                return null;
            else
            {
                EquipmentQuote model = new EquipmentQuote();
                QuoteQuery query = new Domain.Data.Queries.QuoteQuery() { ID = QuoteID };
                EWS.Domain.Data.DataModel.Quote entity = _queryProcessor.Execute<EWS.Domain.Data.DataModel.Quote>(query);

                model.QuoteID = QuoteID;
                model.QuoteRef = entity.QuoteRef;
                model.TenderNumber = entity.TenderNo;
                model.VAT = Convert.ToDecimal(entity.VAT);   
                model.EquipmentSellingPriceExclVAT = entity.SellingPrice;
                model.EquipmentSellingPriceInclVAT = Math.Round(entity.SellingPrice * Convert.ToDecimal(entity.VAT/100 + 1), 2);


                model.ExchangeRate = new ExchangeRate()
                {
                    Rate = entity.ROE,
                    Date = entity.ROEDate
                };

                model.ContractTypesCalculation = GetModelList(QuoteID);
                foreach (ContractCalculation calcmodel in model.ContractTypesCalculation)
                {

                    EWS.Domain.Events.Quoting helper = new EWS.Domain.Events.Quoting()
                    {
                        SellingPrice = entity.SellingPrice,
                        VATRate = entity.VAT ,
                        RateOfExchange = entity.ROE,
                        RateOfExchangeDate = entity.ROEDate,
                        SellingPricePerc = calcmodel.SellingPricePerc,
                        ROEPortion = calcmodel.ROEPortion,
                        StartDate = model.StartDate == DateTime.MaxValue? (DateTime?)null: model.StartDate
                    };

                    calcmodel.QuotePerYear = helper.GetYears(10);

                }
                return model;
            }
        }


        public List<ContractCalculation> GetModelList(int QuoteID)
        {
            List<ContractCalculation> modellist = new List<ContractCalculation>();

            QuoteCalculationsQuery qry = new QuoteCalculationsQuery() { QuoteID = QuoteID};
            IEnumerable<EWS.Domain.Data.DataModel.QuoteCalculation> entitylist = _queryProcessor.Execute(qry);

            foreach (EWS.Domain.Data.DataModel.QuoteCalculation entity in entitylist)
            {
                ContractCalculation model = new ContractCalculation()
                {
                    ContractTypeID = entity.ContractTypeID,
                    ContractType = entity.ContractType.ContractTypeName,
                    SellingPrice = entity.SellingPricePercAmount / (entity.SellingPricePerc / 100),
                    SellingPricePerc = entity.SellingPricePerc,                   
                    ROEPortion = entity.ROEPortion,
                    ZARPortion = entity.ZARPortion,
                    ROEPortionAmount = entity.ROEPortionAmount,
                    ZARPortionAmount = entity.ZARPortionAmount
                };
                modellist.Add(model);
            }

            return modellist;
        }

        private EWS.Domain.Data.DataModel.Quote GetExistingQuote(string QuoteRef)
        {
            QuoteQuery query = new Domain.Data.Queries.QuoteQuery() { QuoteRef = QuoteRef };
            EWS.Domain.Data.DataModel.Quote founditem = _queryProcessor.Execute<EWS.Domain.Data.DataModel.Quote>(query);

            return founditem;
        }

    } //class
} //namespace
