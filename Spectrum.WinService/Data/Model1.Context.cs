﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DocumentMetaField> DocumentMetaFields { get; set; }
        public virtual DbSet<DocumentMetaValue> DocumentMetaValues { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentTypeCategory> DocumentTypeCategories { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<DocumentVersionExpiry> DocumentVersionExpiries { get; set; }
        public virtual DbSet<DocumentVersion> DocumentVersions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }
}
