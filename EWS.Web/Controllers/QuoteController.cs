using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EWS;
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


        // ///////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public virtual ActionResult ChooseMode()
        {
            Models.ChooseMode_Model model = new Models.ChooseMode_Model();
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult ChooseMode(Models.ChooseMode_Model model)
        {
            if (Request.IsAjaxRequest())
            {
                QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
               
                if (model.Mode == Models.ChooseMode_Model.CalculationMode.Equipment && !string.IsNullOrEmpty(model.QuoteRef))
                {
                    model.Quotes = srv.GetSourceQuotes(model.QuoteRef.Trim());
                    return PartialView("_SourceQuoteList", model.Quotes);
                }
                else
                {
                    return Content("");
                }
            }
            else
            {
                if (model.Mode == Models.ChooseMode_Model.CalculationMode.Equipment)
                {
                    if (QuoteRefExists(model.QuoteRef))
                        return RedirectToActionPermanent(MVC.Quote.EnterEquipment(model.QuoteRef));
                    else
                    
                        ViewBag.Message = "Quote Reference not found.";

                }
                else if (model.Mode == Models.ChooseMode_Model.CalculationMode.Current)
                {
                    return RedirectToActionPermanent(MVC.Quote.ChooseContract());
                }

            }

            return View(model);
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public virtual ActionResult ChooseContract()
        {
            Models.SearchContracts model = new Models.SearchContracts();
            model.Contracts = new List<Contract>();
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult ChooseContract(Models.SearchContracts model)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            model.Contracts = srv.GetContracts(model.Keyword);
            return View(model);
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public virtual ActionResult EnterEquipment(string QuoteRef)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            Domain.Model.EnterEquipmentQuote model = srv.GetModel<Domain.Model.EnterEquipmentQuote>(QuoteRef);

            LoadContractTermData(srv);

            return View(model);
        }

        public virtual ActionResult EnterEquipment(EWS.Domain.Model.EnterEquipmentQuote model)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            if (ModelState.IsValid)
            {
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
            LoadContractTermData(srv);
            return View(model);
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public virtual ActionResult EnterCurrent(int ContractID)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            Domain.Model.EnterCurrentQuote model = srv.GetModel<Domain.Model.EnterCurrentQuote>(ContractID.ToString());
            LoadContractTermData(srv);
            return View(model);
        }

        public virtual ActionResult EnterCurrent(EWS.Domain.Model.EnterCurrentQuote model)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            if (ModelState.IsValid)
            {                
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
            LoadContractTermData(srv);
            return View(model);
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public virtual ActionResult Quote(int QuoteID)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            Domain.Model.Quote model = srv.GetModel<Domain.Model.Quote>(QuoteID);
            return View(model);
        }

        public virtual ActionResult Quote (Domain.Model.Quote model)
        {
            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            if (Request.IsAjaxRequest())
            {
                if (model.ContractCalculations != null)
                { 
                    foreach (EWS.Domain.Model.QuoteCalculation calc in model.ContractCalculations)
                    {
                        calc.QuoteCalculationItems = srv.Recalculate(calc, calc.QuoteCalculationItems, model.StartDate);
                    }
                }
                else
                {
                    model = srv.GetModel<Domain.Model.Quote>(model.Id);
                }
                return View("_", model.ContractCalculations);
               
            }
            else 
            {              
                srv.SaveQuote(model);
            }


            return RedirectToActionPermanent(MVC.Quote.FinaliseQuote(model.Id));
        }


        // ///////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public virtual ActionResult FinaliseQuote(int QuoteID)
        {

            ContractService csrv = new ContractService(_commandProcessor, _queryProcessor, _currentUserFactory);

            EWS.Web.Models.FinaliseQuote_Model model = new EWS.Web.Models.FinaliseQuote_Model();
            model.QuoteID = QuoteID;
        
            model.Devices = csrv.GetCoveredItems(QuoteID);
            model.Inclusions = csrv.GetContractInclusions(QuoteID);
            
            model.PrintOptions = new Models.PrintOptions_Model();

            return View(model);
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////
        private void LoadContractTermData(QuoteService srv)
        {
            ViewData["ContractTerms"] = srv.GetContractTerms();
        }

        private bool QuoteRefExists(string QuoteRef)
        {

            QuoteService srv = new QuoteService(_commandProcessor, _queryProcessor, _currentUserFactory);
            if (srv.GetSourceQuote(QuoteRef) == null) return false;
            else return true;
        }

    }
}