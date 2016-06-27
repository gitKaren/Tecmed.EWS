using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EWS.Web.Logic;

namespace EWS.Web.Models
{
    public class ContractInclusionAdmin_Model
    {
        public short ID { get; set; }

        public string ModalityID { get; set; }

        [Required]
        public string Description { get; set; }

        public bool CanBeDeleted { get; set; }

        public IEnumerable<ResultMessage> Results {get; set;}
    }
}