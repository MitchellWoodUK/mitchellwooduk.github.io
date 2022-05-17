using Assignment2Project.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Project.Models
{
    public class AssetModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Rooms Need to Have a Name."))]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public RoomModel Room { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public AssetCategoryModel Category { get; set; }
    }
}
