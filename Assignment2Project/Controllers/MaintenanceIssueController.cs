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
                
                RoomList = _db.Rooms.Where(n => n.InstitutionId == loggedIn.InstitutionId).Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
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
                issueModel.AssetId = model.SelectedAsset;
                issueModel.RoomId = model.SelectedRoom;
                issueModel.IsResolved = false;
                issueModel.InstitutionId = loggedIn.InstitutionId;
                await _db.MaintenanceIssues.AddAsync(issueModel);
                await _db.SaveChangesAsync();
                //Redirects to the Issues action in the Home controller.
                return RedirectToAction( "Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IEnumerable<SelectListItem> GetAssets(int selectedRoom)
        {
            if (selectedRoom != null)
            {
                var AssetList = _db.Assets
                    .Where(n => n.Room.Id == selectedRoom)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name
                        }).ToList();
                return new SelectList(AssetList, "Value", "Text");
            }
            return null;
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("MaintenanceIssues", "Home");
            }
            var issue = await _db.MaintenanceIssues.Where(x => x.Id == id).FirstOrDefaultAsync();
            issue.MaintenanceComments = await _db.MaintenanceComments.Where(x => x.MaintenanceIssueId == issue.Id).Include("User").OrderByDescending(x => x.TimeStamp).ToListAsync();
            if (issue == null)
            {
                return RedirectToAction("MaintenanceIssues", "Home");
            }
            return View(issue);
        }
    }
}
