using Assignment2Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Project.Models
{
    public class GeneralResolutionModel
    {
        [Key]
        public int Id { get; set; }
        public int GeneralIssueId { get; set; }
        [Required]
        public DateTime DateResolved { get; set; }

        [Required]
        [Display(Name = "User Resolving Issue")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CustomUserModel User { get; set; }

        public string Details { get; set; }
    }
}
