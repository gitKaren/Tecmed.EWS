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
    
    public partial class DocumentVersion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentVersion()
        {
            this.DocumentVersionExpiries = new HashSet<DocumentVersionExpiry>();
        }
    
        public System.Guid documentID { get; set; }
        public int VersionNumber { get; set; }
        public string FileName { get; set; }
        public System.DateTime VersionDate { get; set; }
        public long FileSize { get; set; }
        public string VersionCreator { get; set; }
    
        public virtual Document Document { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentVersionExpiry> DocumentVersionExpiries { get; set; }
    }
}