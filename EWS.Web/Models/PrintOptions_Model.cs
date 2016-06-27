using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EWS.Web.Models
{
    public class PrintOptions_Model
    {
        public enum LogoOption
        {
            [Display(Name = "No Logo")]
            NoLogo = 1,
            [Display(Name = "Use Default")]
            Default = 2,
            [Display(Name = "Company")]
            Company = 3
        }

        public enum SignatureOption
        {
            [Display(Name = "Digital")]
            Digital = 1,
            [Display(Name = "Blank")]
            Blank = 2,
        }
        public LogoOption Logo { get; set; }

        public string CompanyLogo { get; set; }

        public SignatureOption Signature { get; set; }



    }
}