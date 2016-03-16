using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWS.Domain.Events
{
    public class Quoting
    {
        public decimal SellingPrice { get; set; }
        public float VATRate { get; set; }

        public decimal RateOfExchange { get; set; }
        public DateTime RateOfExchangeDate { get; set; }

        public decimal SellingPricePerc { get; set; }
        public decimal ROEPortion { get; set; }

        public decimal YearlyIncrement { get; set; }

        public DateTime? StartDate { get; set; }

        public decimal SellingPriceInclVAT { 
            get { 
                return SellingPrice + (SellingPrice * (1 + Convert.ToDecimal(VATRate/100))); 
            } 
        }

        public Quoting() { 
            YearlyIncrement = 5; 
        }


        public IEnumerable<EWS.Domain.Model.OneYearCalculation> GetYears(short NoOfYears)
        {
            // instantiate:
            EWS.Domain.Model.OneYearCalculation[] list = new Model.OneYearCalculation[NoOfYears];

            for (short i = 0; i < NoOfYears; i++)
            {
                list[i] = new EWS.Domain.Model.OneYearCalculation();
            }

            EWS.Domain.Model.OneYearCalculation yr, yrBefore;

            decimal incr = YearlyIncrement / 100;
            decimal vat = Convert.ToDecimal(VATRate / 100);
            
            // populate: 
            yr = list[0];
            yr.YearNo = 1;

            yr.TOPSROE = RateOfExchange;
            yr.NewROE = RateOfExchange;

            yr.AmountExclVAT = SellingPrice * SellingPricePerc / 100;
            yr.AmountInclVAT = yr.AmountExclVAT * (1 + vat);

            yr.ROEPortion = yr.AmountExclVAT * ROEPortion / 100 / RateOfExchange;
            yr.ZARPortion = yr.AmountExclVAT / 100 * (100 - ROEPortion) / 100;

            yr.StartDate = StartDate;
            yr.EndDate = StartDate.HasValue? StartDate.Value.AddYears(1).AddDays(-1): (DateTime?)null;



            for (short i = 1; i < NoOfYears; i++)
            {
                yr = list[i];
                yrBefore = list[i - 1];

                yr.YearNo = Convert.ToInt16(i + 1);
                yr.TOPSROE = RateOfExchange;
                yr.NewROE = RateOfExchange;

                yr.AmountExclVAT = yrBefore.AmountExclVAT * (1 + incr);
                yr.AmountInclVAT = yr.AmountExclVAT * (1 + vat);

                yr.ROEPortion = yrBefore.ROEPortion * (1 + incr);
                yr.ZARPortion = yr.AmountExclVAT * (100 - ROEPortion) / 100;

                yr.StartDate = yrBefore.StartDate.HasValue ? yrBefore.StartDate.Value.AddYears(1) : (DateTime?)null;
                yr.EndDate = yr.StartDate.HasValue ? yr.StartDate.Value.AddYears(1).AddDays(-1) : (DateTime?)null;


            }

            return list;

        }



    }
}
