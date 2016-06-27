using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EWS.Domain.Model;

namespace EWS.Web.Models
{
    public class FinaliseQuote_Model
    {

        public int QuoteID { get; set; }

        public Device[] Devices { get; set; }

        public EWS.Domain.Data.DataModel.ContractInclusion[] Inclusions { get; set; }

        public PrintOptions_Model PrintOptions { get; set; }
       
    }
}