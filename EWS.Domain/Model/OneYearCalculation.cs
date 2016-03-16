using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EWS.Domain.Model
{
    public class OneYearCalculation
    {
        [Required]
        [Display(Name = "Year")]
        public short YearNo { get; set; }

        [Required]
        [Display(Name = "$ Portion")]
        public decimal ROEPortion { get; set; }

        [Required]
        [Display(Name = "R Portion")]
        public decimal ZARPortion { get; set; }

        [Required]
        [Display(Name = "Excluding")]
        public bool ExcludingROE  { get; set; }

        [Required]
        [Display(Name = "TOPS R.O.E.")]
        public decimal TOPSROE { get; set; }

        [Required]
        [Display(Name = "New R.O.E.")]
        public decimal NewROE { get; set; }

        [Required]
        [Display(Name = "Total Excl VAT")]
        public decimal AmountExclVAT { get; set; }

        [Required]
        [Display(Name = "Start"), DisplayFormat(DataFormatString="{0:yyyy/MM/dd}")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "End"), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Total Incl VAT")]
        public decimal AmountInclVAT { get; set; }

    }
}
