using System.ComponentModel.DataAnnotations;

namespace Assignment2Project.Models
{
    public class IssueViewModel
    {
        [Display(Name = "Institution")]
        public InstitutionModel Institution { get; set; }
        public RoomModel Room { get; set; }
        public AssetModel Asset { get; set; }
        public List<MaintenanceIssueModel> MaintenanceIssues { get; set; }
        public List<GeneralIssueModel> GeneralIssues { get; set; }

    }
}
