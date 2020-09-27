using System;
using System.ComponentModel.DataAnnotations;

namespace SF.DATA.EF
{
    public class CategoryMetadata
    {
        [Required]
        [StringLength(1000)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Category Description")]
        public string CatDescription { get; set; }

        [Display(Name = "Main Category")]
        public Nullable<int> MainCategoryID { get; set; }
    }

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category { }
}
