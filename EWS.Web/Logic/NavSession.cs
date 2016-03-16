using Spectrum.SharedKernel.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWS.Web.Logic
{
    public class NavSession
    {
        public static void SetMenu(List<MainMenuItem> menu)
        {
            HttpContext.Current.Session["MenuItems"] = menu;
        }

        public static void ClearMenu()
        {
            HttpContext.Current.Session["MenuItems"] = null;
        }

        public static List<MainMenuItem> GetMenu()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["MenuItems"] != null)
            {
                return (List<MainMenuItem>)HttpContext.Current.Session["MenuItems"];
            }
            else
            {
                var ufac = new CurrentUserFactory();
                var user = ufac.GetCurrentUser();
                if (user != null)
                {
                    int systemId = systemId = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SystemId"]);

                    UserNavigation unav = new UserNavigation(user, systemId);
                    SetMenu(unav.MenuItems);
                    return (List<MainMenuItem>)HttpContext.Current.Session["MenuItems"];
                }
            }
            return null;
        }
    }
}