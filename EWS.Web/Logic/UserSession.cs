using Spectrum.SharedKernel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWS.Web.Logic
{
    public class UserSession
    {
        public static void SetUser(SecurityUser user)
        {
            HttpContext.Current.Session["SecurityUser"] = user;
        }

        public static void ClearUser()
        {
            HttpContext.Current.Session["SecurityUser"] = null;
        }

        public static SecurityUser GetUser()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["SecurityUser"] != null)
            {
                return (SecurityUser)HttpContext.Current.Session["SecurityUser"];
            }
            else
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    return SecurityUser.GetByUserName(HttpContext.Current.User.Identity.Name);
                }
            }
            return null;
        }
    }
}