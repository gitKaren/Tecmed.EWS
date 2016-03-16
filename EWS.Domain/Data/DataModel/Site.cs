//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EWS.Domain.Data.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Site
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Site()
        {
            this.Departments = new HashSet<Department>();
        }
    
        public int ID { get; set; }
        public string SiteRef { get; set; }
        public string SiteName { get; set; }
        public int customerID { get; set; }
        public int marketSegmentID { get; set; }
        public int supportBranchID { get; set; }
        public bool Deleted { get; set; }
        public string RegistrationNo { get; set; }
        public string VATNo { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
