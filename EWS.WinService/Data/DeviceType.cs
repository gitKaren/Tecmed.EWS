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
    
    public partial class DeviceType
    {
        public int ID { get; set; }
        public System.Guid subModalityID { get; set; }
        public string DeviceTypeName { get; set; }
        public bool RadiationEmitting { get; set; }
        public bool Deleted { get; set; }
    
        public virtual SubModality SubModality { get; set; }
    }
}
