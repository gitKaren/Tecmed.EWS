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
    
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            this.ContractItems = new HashSet<ContractItem>();
        }
    
        public int ID { get; set; }
        public Nullable<int> QuoteID { get; set; }
        public string TenderNo { get; set; }
        public int CustomerID { get; set; }
        public int DeviceID { get; set; }
        public short ContractTypeID { get; set; }
        public System.DateTime ContractDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public byte ContractTerm { get; set; }
        public decimal ROE { get; set; }
        public System.DateTime ROEDate { get; set; }
        public float VAT { get; set; }
        public bool Deleted { get; set; }
    
        public virtual ContractTerm ContractTerm1 { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Device Device { get; set; }
        public virtual Quote Quote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractItem> ContractItems { get; set; }
    }
}