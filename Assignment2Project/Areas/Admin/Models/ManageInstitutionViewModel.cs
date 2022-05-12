using Assignment2Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment2Project.Areas.Admin.Models
{
    public class ManageInstitutionViewModel
    {
        public CustomUserModel User { get; set; }

        public IEnumerable<SelectListItem> InstitutionList { get; set; }

    }
}
