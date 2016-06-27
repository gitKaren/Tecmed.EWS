//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spectrum.WinService.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuoteCalculation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuoteCalculation()
        {
            this.QuoteCalculationItems = new HashSet<QuoteCalculationItem>();
        }
    
        public int ID { get; set; }
        public int QuoteID { get; set; }
        public short ContractTypeID { get; set; }
        public decimal SellingPricePerc { get; set; }
        public decimal SellingPricePercAmount { get; set; }
        public decimal BasePrice { get; set; }
        public decimal ROEPortion { get; set; }
        public decimal ZARPortion { get; set; }
        public decimal ROEPortionAmount { get; set; }
        public decimal ZARPortionAmount { get; set; }
    
        public virtual ContractType ContractType { get; set; }
        public virtual Quote Quote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuoteCalculationItem> QuoteCalculationItems { get; set; }
    }
}
