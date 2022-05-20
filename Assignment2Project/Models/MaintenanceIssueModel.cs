
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Project.Models
{
    public class MaintenanceIssueModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime TimeRaised { get; set; }

        [Required]
        [Display(Name = "User Opening Issue")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CustomUserModel User { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public int AssetId { get; set; }
        [ForeignKey("AssetId")]
        public AssetModel Asset { get; set; }

        [Required]
        public bool IsResolved { get; set; }

        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionModel Institution { get; set; }
    }
}
