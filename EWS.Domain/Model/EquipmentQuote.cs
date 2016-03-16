using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EWS.Domain.Model
{
    public class EquipmentQuote 
    {
        public int QuoteID { get; set; }

        [Display(Name = "Reference Quote")]
        public string QuoteRef { get; set; }

        [Display(Name = "Tender Number")]
        public string TenderNumber { get; set; }

        public int CustomerID { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Equipment Selling Price"), DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal EquipmentSellingPriceExclVAT { get; set; }

        [Required]
        [Display(Name = "Equipment Selling Price (VAT Inc)"), DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal EquipmentSellingPriceInclVAT { get; set; }

        public decimal VAT { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "$ Exchange Rate")]
        public ExchangeRate ExchangeRate { get; set; }

        public Device Device { get; set; }

        public IEnumerable<ContractCalculation> ContractTypesCalculation { get; set; }
    }
}
