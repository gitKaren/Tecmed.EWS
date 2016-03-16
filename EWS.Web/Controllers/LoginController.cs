using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Spectrum.SharedKernel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EWS.Web.Logic.Infrastructure;
using EWS.Web.Models;

namespace EWS.Web.Controllers
{
    public partial class LoginController : Controller
    {
        // GET: Login
        public virtual ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Account/Login

        //[ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public virtual ActionResult Index(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Credentials credentials = new Credentials(model.UserName, model.Password);
                try
                {
                    SecurityUser user = SecurityUser.GetByCredentials(credentials);

                    if (user != null)
                    {
                        UserSession.SetUser(user);
                        var ident = new ClaimsIdentity(
                      new[] { new Claim(ClaimTypes.Name, model.UserName) },
                      DefaultAuthenticationTypes.ApplicationCookie);

                        HttpContext.GetOwinContext().Authentication.SignIn(
                           new AuthenticationProperties { IsPersistent = false }, ident);
                        return RedirectToLocal(returnUrl);  // auth succeed 
                    }
                    else
                    {
                        ModelState.AddModelError("", "The username and/or password that you entered is invalid.");
                    }
                }
                catch (UserCredentialsNotValidException ex) 
                {
                    ModelState.AddModelError("", "The username and/or password that you entered is invalid.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "You could not be logged in at this time, due to a technical problem.<br/>" + ex.Message);
                }
            }

            return View();
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            UserSession.ClearUser();
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Login");
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //    //var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    //AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        //}

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());
            //if (user != null)
            //{
            //    return user.PasswordHash != null;
            //}
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}