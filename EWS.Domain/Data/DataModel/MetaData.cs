using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWS.Domain.Data.DataModel
{
    #region Test

    [MetadataType(typeof(TestMetadata))]
    public partial class Test : DbEntity
    {

    }

    public class TestMetadata
    {
        [Required(ErrorMessage = "Test Name is required")]
        public string Test1 { get; set; }
    }

    #endregion

    #region ContractType

    [MetadataType(typeof(ContractTypeMetadata))]
    public partial class ContractType : DbEntity
    {

    }

    public class ContractTypeMetadata
    {
        [Required(ErrorMessage = "ContractType Name is required")]
        public string ContractTypeName { get; set; }
    }

    #endregion

    #region ProductLine

    [MetadataType(typeof(ProductLineMetadata))]
    public partial class ProductLine : DbEntity
    {

    }

    public class ProductLineMetadata
    {
        [Required(ErrorMessage = "ProductLine Name is required")]
        public string ProductLineName { get; set; }
    }

    #endregion

    #region Device

    [MetadataType(typeof(DeviceMetadata))]
    public partial class Device : DbEntity
    {
        public string DisplayName { get { return this.ProductLine.ProductLineName; } }
    }

    public class DeviceMetadata
    {
        [Display(Name = "Description")]
        public string DisplayName { get; set; }
    }

    #endregion

    #region Department

    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department : DbEntity
    {
        
    }

    public class DepartmentMetadata
    {
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }
    }

    #endregion

    #region Modality

    [MetadataType(typeof(ModalityMetadata))]
    public partial class Modality : DbEntity
    {

    }

    public class ModalityMetadata
    {
        [Required(ErrorMessage = "Modality Name is required")]
        public string ModalityName { get; set; }
    }

    #endregion

    #region SubModality

    [MetadataType(typeof(SubModalityMetadata))]
    public partial class SubModality : DbEntity
    {

    }

    public class SubModalityMetadata
    {
        [Required(ErrorMessage = "SubModality Name is required")]
        public string SubModalityName { get; set; }
    }

    #endregion

    #region Supplier

    [MetadataType(typeof(SupplierMetadata))]
    public partial class Supplier : DbEntity
    {

    }

    public class SupplierMetadata
    {
        [Required(ErrorMessage = "Supplier Name is required")]
        public string SupplierName { get; set; }
    }

    #endregion

    #region Country

    [MetadataType(typeof(CountryMetadata))]
    public partial class Country : DbEntity
    {

    }

    public class CountryMetadata
    {
        [Required(ErrorMessage = "Country Name is required")]
        public string CountryName { get; set; }
    }

    #endregion

    #region Site

    [MetadataType(typeof(SiteMetadata))]
    public partial class Site : DbEntity
    {

    }

    public class SiteMetadata
    {
        [Required(ErrorMessage = "Site Name is required")]
        public string SiteName { get; set; }
    }

    #endregion

    #region Room

    [MetadataType(typeof(RoomMetadata))]
    public partial class Room : DbEntity
    {

    }

    public class RoomMetadata
    {
       
    }

    #endregion

    #region Currency

    [MetadataType(typeof(CurrencyMetadata))]
    public partial class Currency : DbEntity
    {

    }

    public class CurrencyMetadata
    {
        [Required(ErrorMessage = "Currency Name is required")]
        public string CurrencyName { get; set; }
    }

    #endregion

    #region Contract

    [MetadataType(typeof(ContractMetadata))]
    public partial class Contract : DbEntity
    {

    }

    public class ContractMetadata
    {

    }

    #endregion

    #region ContractItem

    [MetadataType(typeof(ContractItemMetadata))]
    public partial class ContractItem : DbEntity
    {

    }

    public class ContractItemMetadata
    {

    }

    #endregion

    #region ContractInclusion

    [MetadataType(typeof(ContractInclusionMetadata))]
    public partial class ContractInclusion : DbEntity
    {

    }

    public class ContractInclusionMetadata
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }

    #endregion

    #region ContractTerm

    [MetadataType(typeof(ContractTermMetadata))]
    public partial class ContractTerm : DbEntity
    {
        public static byte DefaultNoOfMonths { get { return 120; } }
    }

    public class ContractTermMetadata
    {
        [Required]
        [Display(Name="No of Months")]
        public byte NoOfMonths { get; set; }

        [Required]
        [Display(Name = "Term")]
        public string Description { get; set; }
       
    }

    #endregion

    #region Customer

    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer : DbEntity
    {
    }

    
    public class CustomerMetadata
    {
        [Required(ErrorMessage = "Customer Name is required")]
        [Display(Name="Customer")]
        public string CustomerName { get; set; }
    }

    #endregion

    #region CustomerLocality

    [MetadataType(typeof(CustomerLocalityMetadata))]
    public partial class CustomerLocality : DbEntity
    {
    }

    
    public class CustomerLocalityMetadata
    {
        [Required(ErrorMessage = "CustomerLocality Name is required")]
        [Display(Name="CustomerLocality")]
        public string CustomerLocalityName { get; set; }
    }

    #endregion
    #region SourceQuote

    [MetadataType(typeof(SourceQuoteMetadata))]
    public partial class SourceQuote : DbEntity
    {

    }

    public class SourceQuoteMetadata
    {
      
    }

    #endregion

    #region Quote

    [MetadataType(typeof(QuoteMetadata))]
    public partial class Quote : DbEntity
    {

    }

    public class QuoteMetadata
    {
       
    }

    #endregion

    #region QuoteCalculation

    [MetadataType(typeof(QuoteCalculationMetadata))]
    public partial class QuoteCalculation : DbEntity
    {

    }

    public class QuoteCalculationMetadata
    {
     
    }

    #endregion

    #region QuoteCalculationItem

    [MetadataType(typeof(QuoteCalculationItemMetadata))]
    public partial class QuoteCalculationItem : DbEntity
    {

    }

    public class QuoteCalculationItemMetadata
    {
        [Required(ErrorMessage = "QuoteCalculation Item Year is required")]
        public int YearNo { get; set; }
    }

    #endregion
}
