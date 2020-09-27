using System;
using System.ComponentModel.DataAnnotations;

namespace SF.DATA.EF
{
    public class ProductMetadata
    {
        [Required]
        [StringLength(1000)]
        public string ProductName { get; set; }

        [Display(Name = "Supplier")]
        public Nullable<int> SupplierID { get; set; }

        [Display(Name = "Category")]
        public Nullable<int> CategoryID { get; set; }

        [StringLength(1000)]
        [Display(Name = "Qty per Unit")]
        public string QuantityPerUnit { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "# in stock")]
        public Nullable<int> UnitsInStock { get; set; }

        [Display(Name = "# on order")]
        public Nullable<int> UnitsOnOrder { get; set; }

        [Display(Name = "Reorder Level")]
        public Nullable<int> ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }
}
