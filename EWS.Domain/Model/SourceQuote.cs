using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Core;
using System.ComponentModel.DataAnnotations;


namespace EWS.Domain.Model
{
    public class SourceQuote : Entity<string>
    {
        [Display(Name = "Ref")]
        public string QuoteRef { get; set; }

        [Required]
        [Display(Name = "Device")]
        public int DeviceID { get; set; }


        [Required]
        [Display(Name = "Device")]
        public string DeviceDescription { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public string Supplier { get; set; }

        [Required]
        [Display(Name = "Date"), DisplayFormat(DataFormatString="{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Selling Price Incl VAT"), DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal SellingPriceInclVAT { get; set; }

        [Required]
        [Display(Name = "VAT"), DisplayFormat(DataFormatString = "{0:C2}")]
        public float VAT { get; set; }

        public bool Selected { get; set; }
    }
}
