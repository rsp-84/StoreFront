using System.ComponentModel.DataAnnotations;

namespace SF.DATA.EF
{
    public class OrderDetailMetadata
    {
        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Discount { get; set; }
    }

    [MetadataType(typeof(OrderDetailMetadata))]
    public partial class OrderDetail { }
}
