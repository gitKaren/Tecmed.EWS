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
namespace T4MVC
{
    public class SharedController
    {

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
                public readonly string _ContractsCalculation = "_ContractsCalculation";
                public readonly string _DeviceInfo = "_DeviceInfo";
                public readonly string _Grid = "_Grid";
                public readonly string _GridPager = "_GridPager";
                public readonly string _Layout = "_Layout";
                public readonly string _SourceQuoteList = "_SourceQuoteList";
                public readonly string _temp = "_temp";
                public readonly string _YearlyCalculation = "_YearlyCalculation";
                public readonly string Error = "Error";
                public readonly string Lockout = "Lockout";
                public readonly string ValidationSummary = "ValidationSummary";
            }
            public readonly string _ContractsCalculation = "~/Views/Shared/_ContractsCalculation.cshtml";
            public readonly string _DeviceInfo = "~/Views/Shared/_DeviceInfo.cshtml";
            public readonly string _Grid = "~/Views/Shared/_Grid.cshtml";
            public readonly string _GridPager = "~/Views/Shared/_GridPager.cshtml";
            public readonly string _Layout = "~/Views/Shared/_Layout.cshtml";
            public readonly string _SourceQuoteList = "~/Views/Shared/_SourceQuoteList.cshtml";
            public readonly string _temp = "~/Views/Shared/_temp.cshtml";
            public readonly string _YearlyCalculation = "~/Views/Shared/_YearlyCalculation.cshtml";
            public readonly string Error = "~/Views/Shared/Error.cshtml";
            public readonly string Lockout = "~/Views/Shared/Lockout.cshtml";
            public readonly string ValidationSummary = "~/Views/Shared/ValidationSummary.cshtml";
            static readonly _EditorTemplatesClass s_EditorTemplates = new _EditorTemplatesClass();
            public _EditorTemplatesClass EditorTemplates { get { return s_EditorTemplates; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _EditorTemplatesClass
            {
                public readonly string ContractCalculation = "ContractCalculation";
                public readonly string ContractCalculations = "ContractCalculations";
                public readonly string Customer = "Customer";
                public readonly string DateTime = "DateTime";
                public readonly string Device = "Device";
                public readonly string ExchangeRate = "ExchangeRate";
                public readonly string QuoteTable = "QuoteTable";
            }
        }
    }

}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
