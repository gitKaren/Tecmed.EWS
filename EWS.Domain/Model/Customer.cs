using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace EWS.Domain.Model
{
    public class Customer : Entity<int>
    {
        public new int Id { get { return base.Id; } set { base.Id = value; } }

        [Display(Name="Customer")]
        public string CustomerName { get; set; }

        public string RegistrationNo { get; set; }
        public string Locality { get; set; }
     

        public Customer()
        {

        }

    }
}
