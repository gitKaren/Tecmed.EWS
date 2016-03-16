// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace EWS.Web.Controllers
{
    public partial class UserController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UserController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UserNavigationTabs()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UserNavigationTabs);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserController Actions { get { return MVC.User; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "User";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "User";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string UserNavigation = "UserNavigation";
            public readonly string UserNavigationTabs = "UserNavigationTabs";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string UserNavigation = "UserNavigation";
            public const string UserNavigationTabs = "UserNavigationTabs";
        }


        static readonly ActionParamsClass_UserNavigationTabs s_params_UserNavigationTabs = new ActionParamsClass_UserNavigationTabs();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UserNavigationTabs UserNavigationTabsParams { get { return s_params_UserNavigationTabs; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UserNavigationTabs
        {
            public readonly string tabMenuId = "tabMenuId";
            public readonly string themeColour = "themeColour";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _UserNavigation = "_UserNavigation";
                public readonly string _UserNavigationTabs = "_UserNavigationTabs";
            }
            public readonly string _UserNavigation = "~/Views/User/_UserNavigation.cshtml";
            public readonly string _UserNavigationTabs = "~/Views/User/_UserNavigationTabs.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_UserController : EWS.Web.Controllers.UserController
    {
        public T4MVC_UserController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void UserNavigationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult UserNavigation()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UserNavigation);
            UserNavigationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void UserNavigationTabsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int tabMenuId, string themeColour);

        [NonAction]
        public override System.Web.Mvc.ActionResult UserNavigationTabs(int tabMenuId, string themeColour)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UserNavigationTabs);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "tabMenuId", tabMenuId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "themeColour", themeColour);
            UserNavigationTabsOverride(callInfo, tabMenuId, themeColour);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
