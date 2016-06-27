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
    
    public partial class SourceQuote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SourceQuote()
        {
            this.Quotes = new HashSet<Quote>();
        }
    
        public string Ref { get; set; }
        public string SupplierID { get; set; }
        public int DeviceID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public System.DateTime Date { get; set; }
        public decimal SellingPriceInclVAT { get; set; }
        public Nullable<decimal> SellingPriceExclVAT { get; set; }
        public float VAT { get; set; }
        public string TenderNumber { get; set; }
        public decimal ROE { get; set; }
        public System.DateTime ROEDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Device Device { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
