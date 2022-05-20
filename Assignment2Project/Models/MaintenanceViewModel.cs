
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment2Project.Models
{
    public class MaintenanceViewModel
    {
        public MaintenanceIssueModel MaintenanceIssue { get; set; }
        public IEnumerable<SelectListItem> AssetList { get; set; }
    }
}
