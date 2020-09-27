using System;
using System.ComponentModel.DataAnnotations;

namespace SF.DATA.EF
{
    public class EmployeeMetadata
    {
        [Required]
        [StringLength(1000)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1000)]
        public string FirstName { get; set; }

        [StringLength(1000)]
        public string Title { get; set; }

        [StringLength(1000)]
        [Display(Name = "Title of Curtesy")]
        public string TitleOfCourtesy { get; set; }

        [Required]
        [Display(Name = "DOB")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime HireDate { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string City { get; set; }

        [StringLength(1000)]
        public string State { get; set; }

        [StringLength(1000)]
        public string PostalCode { get; set; }

        [StringLength(1000)]
        public string HomePhone { get; set; }

        [StringLength(1000)]
        public string Extension { get; set; }

        [UIHint("MultilineText")]
        public string Notes { get; set; }

        [Display(Name = "Manager")]
        public Nullable<int> ReportsTo { get; set; }

        [StringLength(1000)]
        public string PhotoUrl { get; set; }
    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee { }
}
