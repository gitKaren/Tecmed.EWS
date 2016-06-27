using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EWS.Domain.Data.DataModel;

namespace EWS.Web.Models
{
    public class SearchContracts
    {
        [Display(Name = "Calculation Method:")]
        public string Keyword { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}