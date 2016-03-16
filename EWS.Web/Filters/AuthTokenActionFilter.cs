using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Spectrum.SharedKernel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using EWS.Web.Logic.Infrastructure;

namespace EWS.Web.Filters
{
    public class AuthTokenActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSession.GetUser() == null)
            {
                if (!string.IsNullOrEmpty(filterContext.HttpContext.Request.QueryString["authtoken"]))
                {
                    authenticateUser(ref filterContext, filterContext.HttpContext.Request.QueryString["authtoken"]);
                } else if (!string.IsNullOrEmpty(filterContext.HttpContext.Request.QueryString["returnUrl"])) {
                    string queryString = filterContext.HttpContext.Request.QueryString.ToString();
                    if (queryString.Contains("authtoken"))
                    {
                        string[] delim = { "authtoken%3d" };
                        string[] arr = queryString.Split(delim, StringSplitOptions.RemoveEmptyEntries);
                        string token = arr[arr.Length - 1].Substring(0, 36);
                        authenticateUser(ref filterContext, token);
                    }
                }
            }
        }

        private void authenticateUser(ref ActionExecutingContext filterContext, string tokenString)
        {
            byte[] token = Convert.FromBase64String(tokenString);

            if (token == null || token.Length != 32) return;

            SecurityUser user = SecurityUser.GetByAuthenticationToken(token);

            if (user != null)
            {
                UserSession.SetUser(user);
                var ident = new ClaimsIdentity(
                new[] { new Claim(ClaimTypes.Name, user.UserName) },
                DefaultAuthenticationTypes.ApplicationCookie);

                filterContext.HttpContext.GetOwinContext().Authentication.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, ident);
            }
           
        }
    }
}