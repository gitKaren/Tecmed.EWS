using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EWS.Domain.Data;
using EWS.Domain.Data.DataModel;
using EWS.Domain.Model;
using EWS.Web.Logic;
using EWS.Web.Models;
using EWS.Domain.DomainServices;
using EWS.Application.Services;

namespace EWS.Web.Areas.Admin.Controllers
{
    public partial class ContractServicesController : Controller
    {
        ICommandProcessor _commandProcessor;
        IQueryProcessor _queryProcessor;
        ICurrentUserFactory _currentUserFactory;
        IResultMessagesFactory _resultMessagesFactory;

        public ContractServicesController(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, ICurrentUserFactory currentUserFactory, IResultMessagesFactory resultMessagesFactory)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            _currentUserFactory = currentUserFactory;
            _resultMessagesFactory = resultMessagesFactory;           
        }

        // GET: Admin/ContractService
        public virtual ActionResult Index()
        {
            AdminService srv = new AdminService(_commandProcessor, _queryProcessor, _currentUserFactory);
            var model = srv.GetContractInclusionsList();
            return View(model);
        }

        // GET: /Admin/ContractService/Detail/5
        public virtual ActionResult Details(short id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdminService srv = new AdminService(_commandProcessor, _queryProcessor, _currentUserFactory);

            var model = viewModelFrom(srv.GetContractInclusion(id));

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: /Admin/ContractService/Add
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/ContractService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public virtual ActionResult Create([Bind(Include = "Id,ContractServiceName,CanBeDeleted")] ContractInclusionAdmin_Model model)
        {
            if (!ModelState.IsValid)
            {
                string[] errors = ModelState.SelectMany(p => p.Value.Errors).Select(p => p.ErrorMessage).ToArray();
                model.Results = _resultMessagesFactory.GetMessages(ResultMessageType.Error, errors);
                return View(model);
            }

            try
            {
                AdminService srv = new AdminService(_commandProcessor, _queryProcessor, _currentUserFactory);
                srv.CreateContractInclusion(model.Description);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.Results = _resultMessagesFactory.GetMessages(ex);
            }
            return View(model);
        }

        // GET: /Admin/ContractService/Edit/5
        public virtual ActionResult Edit(short id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdminService srv = new AdminService(_commandProcessor, _queryProcessor, _currentUserFactory);

            var model = viewModelFrom(srv.GetContractInclusion(id));

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: /Admin/ContractService/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public virtual ActionResult Edit([Bind(Include = "Id,ContractServiceName")] ContractInclusionAdmin_Model model)
        {
            if (!ModelState.IsValid)
            {
                string[] errors = ModelState.SelectMany(p => p.Value.Errors).Select(p => p.ErrorMessage).ToArray();
                model.Results = _resultMessagesFactory.GetMessages(ResultMessageType.Error, errors);
                return View(model);
            }

            try
            {
                AdminService srv = new AdminService(_commandProcessor, _queryProcessor, _currentUserFactory);
                srv.UpdateContractInclusion(
                    model.ID,
                    model.Description
                    );
                return RedirectToAction("Index");
            } 
            catch (Exception ex)
            {
                model.Results = _resultMessagesFactory.GetMessages(ex);
            }
            return View(model);
        }

        #region Helpers

        private ContractInclusionAdmin_Model viewModelFrom(EWS.Domain.Data.DataModel.ContractInclusion obj)
        {
            if (obj == null) return null;

            return new ContractInclusionAdmin_Model()
            {
                ID = obj.ID,
                Description = obj.Description,
                ModalityID = obj.ModalityID,
                CanBeDeleted = true
            };
        }

        #endregion
    }
}