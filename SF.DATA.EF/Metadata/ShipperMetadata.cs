using System.ComponentModel.DataAnnotations;

namespace SF.DATA.EF
{
    public class ShipperMetadata
    {
        [Required]
        [StringLength(1000)]
        public string CompanyName { get; set; }

        [StringLength(1000)]
        [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$", ErrorMessage = "Please enter a valid phone number format: 555-555-5555")]
        public string Phone { get; set; }
    }
}
