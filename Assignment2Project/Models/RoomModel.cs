using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Project.Models
{
    public class RoomModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Rooms Need to Have a Name."))]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int InstitutionId { get; set; }

        [ForeignKey("InstitutionId")]
        public InstitutionModel Institution { get; set; }
    }
}
