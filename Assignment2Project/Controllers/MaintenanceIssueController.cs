using Assignment2Project.Areas.Admin.Models;
using Assignment2Project.Data;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment2Project.Controllers
{
    public class MaintenanceIssueController : Controller
    {
        public readonly ApplicationDbContext _db;
        public readonly UserManager<CustomUserModel> _userManager;
        public MaintenanceIssueController(ApplicationDbContext db, UserManager<CustomUserModel> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create()
        {
            //Sends the Create view a select list item of the assets for the institution of the user logged in.
           var loggedIn = await _userManager.GetUserAsync(User);
            MaintenanceViewModel maintenanceVM = new MaintenanceViewModel()
            {
                MaintenanceIssue = new MaintenanceIssueModel(),
                AssetList = _db.Assets.Where(n => n.Room.InstitutionId == loggedIn.InstitutionId).Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
              
            };
            return View(maintenanceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaintenanceViewModel model)
        {
            //Returns the data needed to create a maintenance issue from the create view.
            var loggedIn = await _userManager.GetUserAsync(User);

            if (model != null)
            {
                MaintenanceIssueModel issueModel = new MaintenanceIssueModel();
                issueModel.TimeRaised = DateTime.Now;
                issueModel.UserId = loggedIn.Id;
                issueModel.Details = model.MaintenanceIssue.Details;
                issueModel.AssetId = model.MaintenanceIssue.AssetId;
                issueModel.IsResolved = false;
                issueModel.InstitutionId = loggedIn.InstitutionId;
                await _db.MaintenanceIssues.AddAsync(issueModel);
                await _db.SaveChangesAsync();
                //Redirects to the Issues action in the Home controller.
                return RedirectToAction( "Issues", "Home");
            }
            return RedirectToAction("Issues", "Home");
        }
    }
}
