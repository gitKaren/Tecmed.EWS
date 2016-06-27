using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EWS.Web.Models
{
    public class ChooseMode_Model
    {
        public ChooseMode_Model()
        {
            Mode = CalculationMode.Equipment;
        }

        public enum CalculationMode
        {
            [Display(Name = "Current")]
            Current = 1,
            [Display(Name = "Equipment")]
            Equipment = 2
        }

        [Display(Name = "Calculation Method:")]
        public CalculationMode Mode { get; set; }


        //[Display(Name = "Current:")]
        //public bool CurrentCalculationMethod { get; set; }

        //[Display(Name = "Equipment:")]
        //public bool EquipmentCalculationMethod { get; set; }

        [Display(Name = "Input Quote Number")]
        public string QuoteRef { get; set; }

        [Display(Name = "Input Quote Number")]
        public IEnumerable<EWS.Domain.Model.SourceQuote> Quotes { get; set; }
       
    }
}