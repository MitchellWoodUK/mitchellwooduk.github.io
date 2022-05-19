using System.ComponentModel.DataAnnotations;

namespace Assignment2Project.Models
{
    public class IssueViewModel
    {
        [Display(Name = "Institution")]
        public InstitutionModel Institution { get; set; }
        public List<MaintenanceIssueModel> MaintenanceIssues { get; set;}
        public List<GeneralIssueModel> GeneralIssues { get; set; }

    }
}
