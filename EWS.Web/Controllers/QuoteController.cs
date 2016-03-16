using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EWS.Domain.Data;
using EWS.Domain.Data.DataModel;
using EWS.Domain.DomainServices;
using EWS.Web;
using EWS.Application.Services;

namespace EWS.Web.Controllers
{
    [Authorize]
    public partial class QuoteController : Controller
    {
        ICommandProcessor _commandProcessor;
        IQueryProcessor _queryProcessor;
        ICurrentUserFactory _currentUserFactory;

        public QuoteController(ICommandProcessor commandProcessor
                                , IQueryProcessor queryProcessor
                                , ICurrentUserFactory currentUserFactory)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            _currentUserFactory = currentUserFactory;
        }


        public virtual ActionResult ChooseMode(string Method)
        {
            if (Method == "New")
            {
                EWS.Domain.Data.Queries.ContractTypesQuery query = new Domain.Data.Queries.ContractTypesQuery();
                IEnumerable<EWS.Domain.Data.DataModel.ContractType> ContractTypes = _queryProcessor.Execute<IEnumerable<EWS.Domain.Data.DataModel.ContractType>>(query);
                ViewData["ContractTypeID"] = new SelectList(ContractTypes, "ID", "ContractTypeName");

                EWS.Domain.Data.Queries.DevicesQuery query2 = new Domain.Data.Queries.DevicesQuery();

                IEnumerable<EWS.Domain.Model.Device> Devices = _queryProcessor.Execute<IEnumerable<EWS.Domain.Model.Device>>(query2);
                ViewData["DeviceID"] = new SelectList(Devices, "ID", "DisplayName");

                return View("NewContractForm");
            }
            else if (Method == "Current")
            {
                
                return View("Current");
            }
            else 
                return View();

        }

        [HttpGet]
        public virtual ActionResult NewQuote()
        {
            Models.QuoteStart_Model model = new Models.QuoteStart_Model();
            return View(model);
        }


        [HttpPost]
        public virtual ActionResult NewQuote(Models.QuoteStart_Model model)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);

            if (model.Mode == Models.QuoteStart_Model.CalculationMode.Equipment && string.IsNullOrEmpty(model.QuoteRef))
            {
                return View();
            }
            if (model.Mode == Models.QuoteStart_Model.CalculationMode.Equipment && model.QuoteRef.Trim() != string.Empty)
            {
                model.Quotes = srv.GetSourceQuotes(model.QuoteRef.Trim());
            }
            else
            {
                model.Mode = Models.QuoteStart_Model.CalculationMode.Equipment;
                model.Quotes = srv.GetSourceQuotes(null);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_SourceQuoteList", model.Quotes);
            }

            else if (model.Mode == Models.QuoteStart_Model.CalculationMode.Equipment)
            {

                return RedirectToActionPermanent(MVC.Quote.EquipmentCalculation(model.QuoteRef));
            }
            else
                return View();
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public virtual ActionResult EquipmentCalculation(string QuoteRef)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
         
            EWS.Domain.Model.EquipmentQuoteStep1 model = srv.GetModel(QuoteRef);


            return View(model);
        }

        public virtual ActionResult EquipmentCalculation(EWS.Domain.Model.EquipmentQuoteStep1 model)
        {
            if (ModelState.IsValid)
            {
                QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);


                string errmsg = srv.SaveQuote(model);
                if (errmsg == string.Empty)
                {
                    return RedirectToActionPermanent(MVC.Quote.Quote(model.QuoteID));
                }
                else
                {
                    ModelState.AddModelError("", errmsg);
                }
            }    
            return View(model);
        }

        public virtual ActionResult Quote(int QuoteID)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            EWS.Domain.Model.EquipmentQuote model = srv.GetModel(QuoteID);
            return View(model);
        }

    }
}