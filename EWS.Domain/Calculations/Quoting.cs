using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWS.Domain.Events
{
    public class Quoting
    {
        //public decimal SellingPrice { get; set; }

        //public decimal RateOfExchange { get; set; }
        //public DateTime RateOfExchangeDate { get; set; }

        //public decimal SellingPricePerc { get; set; }
        //public decimal ROEPortion { get; set; }

        public decimal ROEPortionAmount { get; set; }
        public decimal ZARPortionAmount { get; set; }


        public DateTime? StartDate { get; set; }


        public Quoting() { 
            
        }

        public void ApplyCalculationLogic(ref EWS.Domain.Model.QuoteCalculationItem[] items)
        {
            EWS.Domain.Model.QuoteCalculationItem yr, yrBefore;
            yr = items[0];

            decimal incr = Defaults.AnnualIncrement / 100;
            decimal vat = (decimal)(yr.VAT / 100);

            yr.ROEPortion = ROEPortionAmount / yr.TOPSROE;
            yr.ZARPortion = ZARPortionAmount;

            if (yr.UseNewROE) {
                yr.AmountExclVAT = yr.ROEPortion * (yr.NewROE / 100) + ZARPortionAmount;
            }
            else { 
                yr.AmountExclVAT = ROEPortionAmount * (yr.TOPSROE / 100) + ZARPortionAmount;              
            }

            yr.AmountInclVAT = yr.AmountExclVAT * (1 + vat);

            yr.StartDate = StartDate;
            if (StartDate.HasValue)  yr.EndDate = StartDate.Value.AddYears(1).AddDays(-1);

            for (short i = 1; i < items.Count(); i++)
            {
                yr = items[i];
                yrBefore = items[i - 1];

                incr = (yr.Increment / 100);


                yr.ROEPortion = yrBefore.ROEPortion * (1 + incr);
                yr.ZARPortion = yrBefore.ZARPortion * (1 + incr);

                if (yr.UseNewROE)
                {
                    yr.AmountExclVAT = yr.ROEPortion * (yr.NewROE / 100) + yr.ZARPortion;
                }
                else
                {
                    yr.AmountExclVAT = yr.ROEPortion * (yr.TOPSROE / 100) + yr.ZARPortion;
                }

                yr.AmountInclVAT = yr.AmountExclVAT * (1 + vat);


                if (StartDate.HasValue)
                {
                    yr.StartDate = StartDate.Value.AddYears(i);
                    yr.EndDate = StartDate.Value.AddYears(i + 1).AddDays(-1);
                }

            }
        }



        //public EWS.Domain.Model.QuoteCalculationItem[] GetYears(short NoOfYears)
        //{
        //    // instantiate:
        //    EWS.Domain.Model.QuoteCalculationItem[] list = new Model.QuoteCalculationItem[NoOfYears];

        //    for (short i = 0; i < NoOfYears; i++)
        //    {
        //        list[i] = new EWS.Domain.Model.QuoteCalculationItem();
        //    }

        //    EWS.Domain.Model.QuoteCalculationItem yr, yrBefore;

        //    decimal incr = Defaults.AnnualIncrement / 100;
        //    decimal vat = Convert.ToDecimal(VATRate / 100);
            
        //    // populate: 
        //    yr = list[0];
        //    yr.YearNo = 1;

        //    yr.TOPSROE = RateOfExchange;
        //    yr.NewROE = RateOfExchange;


        //    //yr.ROEPortion = yr.AmountExclVAT * ROEPortion / 100 / RateOfExchange;
        //    //yr.ZARPortion = yr.AmountExclVAT / 100 * (100 - ROEPortion) / 100;
        //    yr.ROEPortion = ROEPortionAmount / RateOfExchange;
        //    yr.ZARPortion = ZARPortionAmount;

        //    // yr.AmountExclVAT = SellingPrice * SellingPricePerc / 100;
        //    if (yr.UseNewROE)
        //        yr.AmountExclVAT = yr.ROEPortion * (yr.NewROE /100) + ZARPortionAmount;
        //    else
        //         yr.AmountExclVAT = ROEPortionAmount + ZARPortionAmount;
        //    yr.AmountInclVAT = yr.AmountExclVAT * (1 + vat);
        //    yr.Increment = 0;

        //    yr.StartDate = StartDate;
        //    yr.EndDate = StartDate.HasValue? StartDate.Value.AddYears(1).AddDays(-1): (DateTime?)null;



        //    for (short i = 1; i < NoOfYears; i++)
        //    {
        //        yr = list[i];
        //        yrBefore = list[i - 1];

        //        yr.Increment = Defaults.AnnualIncrement;   // This should change to get the model value


        //        yr.YearNo = Convert.ToInt16(i + 1);
        //        yr.TOPSROE = RateOfExchange;
        //        yr.NewROE = RateOfExchange;

        //        incr = (yr.Increment / 100);
        //        yr.AmountExclVAT = yrBefore.AmountExclVAT * (1 + incr);
        //        yr.AmountInclVAT = yr.AmountExclVAT * (1 + vat);

        //        yr.ROEPortion = yrBefore.ROEPortion * (1 + incr);
        //        yr.ZARPortion = yrBefore.ZARPortion * (1 + incr);

                

        //        yr.StartDate = yrBefore.StartDate.HasValue ? yrBefore.StartDate.Value.AddYears(1) : (DateTime?)null;
        //        yr.EndDate = yr.StartDate.HasValue ? yr.StartDate.Value.AddYears(1).AddDays(-1) : (DateTime?)null;


        //    }

        //    return list;

        //}



    }
}
