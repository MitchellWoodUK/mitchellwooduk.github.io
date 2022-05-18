using Assignment2Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Assignment2Project.Areas.Admin.Models
{
    public class AssetViewModel
    {
        public AssetModel Asset { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [Display(Name = "Room")]
        public string SelectedRoom { get; set; }
        public IEnumerable<SelectListItem> RoomList { get; set; }
        [Display(Name = "Institution")]
        public string SelectedInstitution { get; set; }
        public IEnumerable<SelectListItem> InstitutionList  { get; set; }
    }
}
