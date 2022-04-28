using Assignment2Project.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment2Project.Areas.Admin.Models
{
    public class ManageUserRoleViewModel
    {
        public CustomUserModel User { get; set; }
        public IdentityRole Role { get; set; }
        public bool IsInRole { get; set; }
    }
}
