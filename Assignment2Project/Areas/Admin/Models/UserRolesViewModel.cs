using Assignment2Project.Models;

namespace Assignment2Project.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public CustomUserModel User { get; set; }
        public List<string> Roles { get; set; }
    }
}
