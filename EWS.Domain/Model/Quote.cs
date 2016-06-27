using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace EWS.Domain.Model
{
    public class Quote : Entity<int>
    {
        public int QuoteID { get { return base.Id; } set { base.Id = value; } }

        public int? ContractID { get; set; }

        [Display(Name = "Reference Quote")]
        public string QuoteRef { get; set; }

        [Display(Name = "Tender Number")]
        public string TenderNumber { get; set; }

        [Display(Name = "VAT")]
        public float VAT { get; set; }

        [Display(Name = "Contract Start")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "Equipment Selling Price"), DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal SellingPriceExclVAT { get; set; }

        [Required]
        [Display(Name = "Equipment Selling Price (VAT Inc)"), DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal SellingPriceInclVAT { get; set; }

        [Required]
        [Display(Name = "Term")]
        public byte NoOfMonths { get; set; }

        [Required]
        [Display(Name = "$ Exchange Rate")]
        public ExchangeRate ExchangeRate { get; set; }


        public Device Device { get; set; }

        public Customer Customer { get; set; }

        public List<QuoteCalculation> ContractCalculations { get; set; }
    }
}
