using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.DATA.EF
{
    public class MainCagegoryMetadata
    {
        [Required]
        [StringLength(1000)]
        [Display(Name = "Main Category")]
        public string MainCategoryName { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Description")]
        public string MainDescription { get; set; }
    }

    [MetadataType(typeof(MainCagegoryMetadata))]
    public partial class MainCategory { }
}
