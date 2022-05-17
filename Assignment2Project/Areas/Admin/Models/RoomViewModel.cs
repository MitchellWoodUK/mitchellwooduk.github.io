using Assignment2Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment2Project.Areas.Admin.Models
{
    public class RoomViewModel
    {
        public RoomModel Room { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> InstitutionList { get; set; }
    }
}
