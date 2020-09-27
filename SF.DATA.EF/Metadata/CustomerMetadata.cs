using System.ComponentModel.DataAnnotations;

namespace SF.DATA.EF
{
    public class CustomerMetadata
    {
        [Required]
        [StringLength(1000)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1000)]
        public string FirstName { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string City { get; set; }

        [StringLength(1000)]
        public string State { get; set; }

        [StringLength(1000)]
        public string PostalCode { get; set; }

        [StringLength(1000)]
        [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$", ErrorMessage = "Please enter a valid phone number format: 555-555-5555")]
        public string Phone { get; set; }

        [StringLength(1000)]
        [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$", ErrorMessage = "Please enter a valid fax number format: 555-555-5555")]
        public string Fax { get; set; }

        [StringLength(1000)]
        [RegularExpression("^((([!#$%&'*+\\-/=?^_`{|}~\\w])|([!#$%&'*+\\-/=?^_`{|}~\\w][!#$%&'*+\\-/=?^_`{|}~\\.\\w]{0,}[!#$%&'*+\\-/=?^_`{|}~\\w]))[@]\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)$", ErrorMessage = "Please enter a valid email address: you@example.com")]
        public string Email { get; set; }
    }

    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer { }
}
