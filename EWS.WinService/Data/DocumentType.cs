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
    
    public partial class DocumentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentType()
        {
            this.Documents = new HashSet<Document>();
        }
    
        public string ID { get; set; }
        public string documentTypeCategoryID { get; set; }
        public string DocumentTypeName { get; set; }
        public bool Deleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }
        public virtual DocumentTypeCategory DocumentTypeCategory { get; set; }
    }
}
