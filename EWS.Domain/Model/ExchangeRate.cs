using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Core;
using System.ComponentModel.DataAnnotations;


namespace EWS.Domain.Model
{
    public class ExchangeRate : ValueObject<ExchangeRate>
    {
        [Required]
        [Display(Name = "$ Exchange Rate"), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Rate { get; set; }

        [Required]
        [Display(Name = "Date"), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }
    }
}
