using System.ComponentModel.DataAnnotations;

namespace SF.DATA.EF
{
    public class SupplierMetadata
    {
        [Required]
        [StringLength(1000)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [StringLength(1000)]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [StringLength(1000)]
        [Display(Name = "Job Title")]
        public string ContactTitle { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string City { get; set; }

        [StringLength(1000)]
        public string State { get; set; }

        [StringLength(1000)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(1000)]
        [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$", ErrorMessage = "Please enter a valid phone number format: 555-555-5555")]
        public string Phone { get; set; }

        [StringLength(1000)]
        [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$", ErrorMessage = "Please enter a valid fax number format: 555-555-5555")]
        public string Fax { get; set; }

        [StringLength(1000)]
        public string WebsiteUrl { get; set; }
    }

    [MetadataType(typeof(SupplierMetadata))]
    public partial class Supplier { }
}
