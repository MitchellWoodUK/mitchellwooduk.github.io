using System.ComponentModel.DataAnnotations;

namespace Assignment2Project.Models
{
    public class IssueViewModel
    {
        [Display(Name = "Institution")]
        public RoomModel Room { get; set; }
        public AssetModel Asset { get; set; }
        public MaintenanceIssueModel MaintenanceIssues { get; set; }

    }
}
