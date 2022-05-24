using System.ComponentModel.DataAnnotations;

namespace Assignment2Project.Models
{
    public class RoomCategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}