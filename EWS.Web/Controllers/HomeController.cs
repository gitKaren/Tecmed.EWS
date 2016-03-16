using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EWS.Domain.Data;
using EWS.Domain.DomainServices;

namespace EWS.Web.Controllers
{
    [Authorize]
    public partial class HomeController : Controller
    {
        ICommandProcessor _commandProcessor;
        IQueryProcessor _queryProcessor;
        ICurrentUserFactory _currentUserFactory;

        public HomeController(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, ICurrentUserFactory currentUserFactory)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            _currentUserFactory = currentUserFactory;
        }


        public virtual ActionResult Index()
        {
            EWS.Application.TestService srv = new Application.TestService(_commandProcessor, _queryProcessor, _currentUserFactory);
            string testName = srv.CreateTestAndReturnName("Ola Mundo");

            return View();
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}