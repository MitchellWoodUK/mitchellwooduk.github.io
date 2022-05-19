using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Project.Models
{
    public class GeneralIssueModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateRaised { get; set; }

        [Required]
        [Display(Name = "User Opening Issue")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CustomUserModel User { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public bool IsResolved { get; set; }

        public int ResolutionId { get; set; }
        [ForeignKey("ResolutionId")]
        public ResolutionModel Resolution { get; set; }
    }
}
