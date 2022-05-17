using System.ComponentModel.DataAnnotations;

namespace Assignment2Project.Areas.Admin.Models
{
    public class AssetCategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Asset Name")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
