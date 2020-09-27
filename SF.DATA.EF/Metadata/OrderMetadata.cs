using System;
using System.ComponentModel.DataAnnotations;

namespace SF.DATA.EF
{
    public class OrderMetadata
    {
        [Display(Name = "Customer")]
        public Nullable<int> CustomerID { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime OrderDate { get; set; }


        public Nullable<System.DateTime> ShippedDate { get; set; }

        [Display(Name = "Shipped By")]
        public Nullable<int> ShipVia { get; set; }

        [Display(Name = "Shipping Cost")]
        public Nullable<decimal> Freight { get; set; }

        [Required]
        public string ShipName { get; set; }

        [Required]
        public string ShipAddress { get; set; }

        [Required]
        public string ShipCity { get; set; }

        [Required]
        public string ShipState { get; set; }

        [Required]
        public string ShipPostalCode { get; set; }
    }

    [MetadataType(typeof(OrderMetadata))]
    public partial class Order { }
}
