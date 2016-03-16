using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EWS.Web.Models
{
    public class SourceQuoteItem_Model
    {
        [Required]
        [Display(Name = "Ref")]
        public string QuoteRef { get; set; }

        [Required]
        [Display(Name = "Device")]
        int DeviceID { get; set; }


        [Required]
        [Display(Name = "Device")]
        string DeviceName { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        string Supplier { get; set; }

        [Required]
        [Display(Name = "Date")]
        string Date { get; set; }

    }
}