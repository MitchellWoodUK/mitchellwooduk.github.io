namespace Assignment2Project.Models
{
    public class HomeViewModel
    {
        public List<AssetModel> Assets { get; set; }
        public List<RoomModel> Rooms { get; set; }
        public List<MaintenanceIssueModel> MaintenanceIssues { get; set; }
        public List<GeneralIssueModel> GeneralIssues { get; set; }
    }
}
