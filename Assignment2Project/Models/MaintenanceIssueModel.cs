
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
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public RoomModel Room { get; set; }

        [Required]
        public int AssetId { get; set; }
        [ForeignKey("AssetId")]
        public AssetModel Asset { get; set; }

        [Required]
        public bool IsResolved { get; set; }
     


        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionModel Institution { get; set; }
        public List<MaintenanceCommentModel> MaintenanceComments { get; set; } = new List<MaintenanceCommentModel>();
        public List<ResolutionModel> ResolutionComments { get; set; } = new List<ResolutionModel>();

    }
}
