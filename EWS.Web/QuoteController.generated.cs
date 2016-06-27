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
    public partial class QuoteController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected QuoteController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult EnterEquipment()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterEquipment);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EnterCurrent()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterCurrent);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Quote()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Quote);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult FinaliseQuote()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.FinaliseQuote);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public QuoteController Actions { get { return MVC.Quote; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Quote";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Quote";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ChooseMode = "ChooseMode";
            public readonly string ChooseContract = "ChooseContract";
            public readonly string EnterEquipment = "EnterEquipment";
            public readonly string EnterCurrent = "EnterCurrent";
            public readonly string Quote = "Quote";
            public readonly string FinaliseQuote = "FinaliseQuote";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ChooseMode = "ChooseMode";
            public const string ChooseContract = "ChooseContract";
            public const string EnterEquipment = "EnterEquipment";
            public const string EnterCurrent = "EnterCurrent";
            public const string Quote = "Quote";
            public const string FinaliseQuote = "FinaliseQuote";
        }


        static readonly ActionParamsClass_ChooseMode s_params_ChooseMode = new ActionParamsClass_ChooseMode();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChooseMode ChooseModeParams { get { return s_params_ChooseMode; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChooseMode
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ChooseContract s_params_ChooseContract = new ActionParamsClass_ChooseContract();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChooseContract ChooseContractParams { get { return s_params_ChooseContract; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChooseContract
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_EnterEquipment s_params_EnterEquipment = new ActionParamsClass_EnterEquipment();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EnterEquipment EnterEquipmentParams { get { return s_params_EnterEquipment; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EnterEquipment
        {
            public readonly string QuoteRef = "QuoteRef";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_EnterCurrent s_params_EnterCurrent = new ActionParamsClass_EnterCurrent();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EnterCurrent EnterCurrentParams { get { return s_params_EnterCurrent; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EnterCurrent
        {
            public readonly string ContractID = "ContractID";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Quote s_params_Quote = new ActionParamsClass_Quote();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Quote QuoteParams { get { return s_params_Quote; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Quote
        {
            public readonly string QuoteID = "QuoteID";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_FinaliseQuote s_params_FinaliseQuote = new ActionParamsClass_FinaliseQuote();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_FinaliseQuote FinaliseQuoteParams { get { return s_params_FinaliseQuote; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_FinaliseQuote
        {
            public readonly string QuoteID = "QuoteID";
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
                public readonly string ChooseContract = "ChooseContract";
                public readonly string ChooseMode = "ChooseMode";
                public readonly string EnterCurrent = "EnterCurrent";
                public readonly string EnterEquipment = "EnterEquipment";
                public readonly string FinaliseQuote = "FinaliseQuote";
                public readonly string NewContractForm = "NewContractForm";
                public readonly string Quote = "Quote";
            }
            public readonly string ChooseContract = "~/Views/Quote/ChooseContract.cshtml";
            public readonly string ChooseMode = "~/Views/Quote/ChooseMode.cshtml";
            public readonly string EnterCurrent = "~/Views/Quote/EnterCurrent.cshtml";
            public readonly string EnterEquipment = "~/Views/Quote/EnterEquipment.cshtml";
            public readonly string FinaliseQuote = "~/Views/Quote/FinaliseQuote.cshtml";
            public readonly string NewContractForm = "~/Views/Quote/NewContractForm.cshtml";
            public readonly string Quote = "~/Views/Quote/Quote.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_QuoteController : EWS.Web.Controllers.QuoteController
    {
        public T4MVC_QuoteController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ChooseModeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChooseMode()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChooseMode);
            ChooseModeOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ChooseModeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, EWS.Web.Models.ChooseMode_Model model);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChooseMode(EWS.Web.Models.ChooseMode_Model model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChooseMode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ChooseModeOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void ChooseContractOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChooseContract()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChooseContract);
            ChooseContractOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ChooseContractOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, EWS.Web.Models.SearchContracts model);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChooseContract(EWS.Web.Models.SearchContracts model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChooseContract);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ChooseContractOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void EnterEquipmentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string QuoteRef);

        [NonAction]
        public override System.Web.Mvc.ActionResult EnterEquipment(string QuoteRef)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterEquipment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "QuoteRef", QuoteRef);
            EnterEquipmentOverride(callInfo, QuoteRef);
            return callInfo;
        }

        [NonAction]
        partial void EnterEquipmentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, EWS.Domain.Model.EnterEquipmentQuote model);

        [NonAction]
        public override System.Web.Mvc.ActionResult EnterEquipment(EWS.Domain.Model.EnterEquipmentQuote model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterEquipment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            EnterEquipmentOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void EnterCurrentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int ContractID);

        [NonAction]
        public override System.Web.Mvc.ActionResult EnterCurrent(int ContractID)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterCurrent);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ContractID", ContractID);
            EnterCurrentOverride(callInfo, ContractID);
            return callInfo;
        }

        [NonAction]
        partial void EnterCurrentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, EWS.Domain.Model.EnterCurrentQuote model);

        [NonAction]
        public override System.Web.Mvc.ActionResult EnterCurrent(EWS.Domain.Model.EnterCurrentQuote model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EnterCurrent);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            EnterCurrentOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void QuoteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int QuoteID);

        [NonAction]
        public override System.Web.Mvc.ActionResult Quote(int QuoteID)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Quote);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "QuoteID", QuoteID);
            QuoteOverride(callInfo, QuoteID);
            return callInfo;
        }

        [NonAction]
        partial void QuoteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, EWS.Domain.Model.Quote model);

        [NonAction]
        public override System.Web.Mvc.ActionResult Quote(EWS.Domain.Model.Quote model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Quote);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            QuoteOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void FinaliseQuoteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int QuoteID);

        [NonAction]
        public override System.Web.Mvc.ActionResult FinaliseQuote(int QuoteID)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.FinaliseQuote);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "QuoteID", QuoteID);
            FinaliseQuoteOverride(callInfo, QuoteID);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
