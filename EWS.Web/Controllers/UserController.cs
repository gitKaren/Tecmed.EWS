using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using EWS.Web.Models;
using System.Net;
using Spectrum.SharedKernel.Navigation;
using Spectrum.SharedKernel.Authentication;
using EWS.Web.Logic;

namespace EWS.Web.Controllers
{
    public partial class UserController : Controller
    {
        private int systemId;

        public UserController()
        {
            systemId = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SystemId"]);
            ViewBag.SystemId = systemId;
            ViewBag.AuthToken = UserSession.GetUser().AuthenticationToken;
        }

        // GET: User
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult UserNavigation()
        {
            //SecurityUser user = SecurityUser.GetByUserName("DevMc");
            //UserNavigation unav = new UserNavigation(user, systemId);
            
            //return PartialView("_UserNavigation", unav.MenuItems);

            return PartialView("_UserNavigation", NavSession.GetMenu());
        }

        public virtual ActionResult UserNavigationTabs(int tabMenuId, string themeColour)
        {
            //if (string.IsNullOrEmpty(themeColour))
            //{
            //    ViewBag.ThemeColour = "steel";
            //}
            //else
            //{
            //    ViewBag.ThemeColour = themeColour;
            //}



            //int selectedTabMenuId = tabMenuId;
            //SecurityUser user = SecurityUser.GetByUserName("DevMc");
            //UserNavigation unav = new UserNavigation(user, systemId);

            //if (selectedTabMenuId <= 0)
            //{
            //    try
            //    {
            //        selectedTabMenuId = unav.MenuItems.FirstOrDefault().Children.FirstOrDefault().Children.FirstOrDefault().Id;
            //    }
            //    catch
            //    {
            //    }
            //}
            //var tabMenus = unav.MenuItems.SelectMany(s => s.Children).SelectMany(t => t.Children);

            //return PartialView("_UserNavigationTabs", tabMenus);

            var menu = NavSession.GetMenu();

            if (string.IsNullOrEmpty(themeColour))
            {
                ViewBag.ThemeColour = "steel";
            }
            else
            {
                ViewBag.ThemeColour = themeColour;
            }

            CurrentMenuFinder menuFinder = new CurrentMenuFinder();
            menuFinder.UpdateCurrentPage();

            if (menu != null)
            {
                var tabMenus = menuFinder.GetTabs();
                return PartialView("_UserNavigationTabs", tabMenus);
            }

            return PartialView("_UserNavigationTabs", new Spectrum.SharedKernel.Navigation.TabMenuItem[]{});
        }

        
    }
}