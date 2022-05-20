using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Project.Models
{
    public class MaintenanceCommentModel
    {
        [Key]
        public int Id { get; set; }
        public int MaintenanceIssueId { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CustomUserModel User { get; set; }
    }
}
