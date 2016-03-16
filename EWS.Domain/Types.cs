using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EWS.Domain
{
    public class Types
    {

        public enum CalculationMode
        {
            [Display(Name = "Current")]
            Current = 1,
            [Display(Name = "Equipment")]
            Equipment = 2
        }

        public enum ContractType : short
        {
            QPC = 1, EWCExcl = 2, EWCIncl = 3
        }


    }
}
