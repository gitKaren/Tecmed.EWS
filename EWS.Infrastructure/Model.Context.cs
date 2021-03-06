﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EWS.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using EWS.Domain.Data.DataModel;
    
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
    
        public virtual DbSet<BrandModel> BrandModels { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerLocality> CustomerLocalities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DeviceComponent> DeviceComponents { get; set; }
        public virtual DbSet<HospitalDepartment> HospitalDepartments { get; set; }
        public virtual DbSet<Modality> Modalities { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<ProductLine> ProductLines { get; set; }
        public virtual DbSet<SubModality> SubModalities { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<SourceQuote> SourceQuotes { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractTerm> ContractTerms { get; set; }
        public virtual DbSet<ContractItem> ContractItems { get; set; }
        public virtual DbSet<QuoteCalculation> QuoteCalculations { get; set; }
        public virtual DbSet<QuoteCalculationItem> QuoteCalculationItems { get; set; }
        public virtual DbSet<ContractInclusion> ContractInclusions { get; set; }
    }
}
