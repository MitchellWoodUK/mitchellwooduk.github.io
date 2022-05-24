
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Assignment2Project.Models
{
    public class MaintenanceViewModel
    {
        public MaintenanceIssueModel MaintenanceIssue { get; set; }
        public int SelectedRoom { get; set; }
        public IEnumerable<SelectListItem> RoomList { get; set; }
        public int SelectedAsset { get; set; }
        public IEnumerable<SelectListItem> AssetList { get; set; }
    }
}