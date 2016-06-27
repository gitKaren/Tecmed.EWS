using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Core;
using System.ComponentModel.DataAnnotations;


namespace EWS.Domain.Model
{
    public class QuoteCalculation : ValueObject<QuoteCalculation>
    {
        public QuoteCalculation()
        {

        }

        public QuoteCalculation(int quoteID, short contractTypeID, string ContractTypeName, decimal SellingPrice, decimal Base_Price, byte ContractTerm)
        {
            ContractTypeID = contractTypeID;
            ContractType = ContractTypeName;
            BasePrice = Base_Price;
            Selected = true;
            if (SellingPrice > 0)
            { 
                SellingPricePerc = 2;
                BasePrice = (decimal)0.02 * SellingPrice;
            }
            ROEPortion = 90;
            ROEPortionAmount = (decimal)0.90 * (decimal)0.02 * BasePrice;
            ZARPortion = 10;
            ZARPortionAmount = (decimal)0.10 * (decimal)0.02 * BasePrice;
        }

        public int ContractCalculationID { get; set; }

        public short ContractTypeID { get; set; }

        public bool Selected { get; set; }

        [Display(Name = "Amount")]
        public decimal BasePrice { get; set; }

        [Required]
        [Display(Name = "Contract")]
        public string ContractType { get; set; }

        [Required]
        [Display(Name = "% of Selling")]
        public decimal SellingPricePerc { get; set; }

        //[Required]
        //[Display(Name = "Amount")]
        //public decimal SellingPricePercAmount { get; set; }

        [Required]
        [Display(Name = "R.O.E.(%)")]
        public decimal ROEPortion { get; set; }

        [Required]
        [Display(Name = "ZAR (%)")]
        public decimal ZARPortion { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal ROEPortionAmount { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal ZARPortionAmount { get; set; }


        //public EWS.Domain.Data.DataModel.ContractTerm ContractTerm { get; set; }

        public QuoteCalculationItem[] QuoteCalculationItems { get; set; }
    }
}
