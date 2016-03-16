using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EWS.Web.Models
{
    public class NewContract_Model
    {
        [Required]
        [Display(Name = "Including Contract Calculation ")]
        public bool InclusiveCalculation { get; set; }

        [Required]
        [Display(Name = "Quote Reference")]
        public string QuoteRef { get; set; }

        [Required]
        [Display(Name = "Device")]
        int DeviceID { get; set; }



    }
}