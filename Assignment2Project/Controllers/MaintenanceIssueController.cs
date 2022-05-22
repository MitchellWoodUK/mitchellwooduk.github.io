using Assignment2Project.Data;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Institution_Manager")]
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
        [Authorize(Roles = "Institution_Manager")]

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
            var VM = new IssueViewModel();

            //Creates a list to populate with IssueViewModels
            //Loops through both the list of maintenance issues and general 
            var user = _db.Users.FirstOrDefault(i => i.Id == issue.UserId);
                var room = _db.Rooms.FirstOrDefault(i => i.Id == issue.RoomId);
                var asset = _db.Assets.FirstOrDefault(i => i.Id == issue.AssetId);
                if (room != null && asset != null)
                {
                    IssueViewModel issueVM = new IssueViewModel()
                    {
                        User = user,
                        MaintenanceIssues = issue,
                        Room = room,
                        Asset = asset
                    };
                VM = issueVM;
                }
            
            return View(VM);
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(string comment, int id)
        {
            var issue = await _db.MaintenanceIssues.Where(x => x.Id == id).FirstOrDefaultAsync();
            issue.MaintenanceComments.Add(new MaintenanceCommentModel
            {
                Comment = comment,
                MaintenanceIssueId = id,
                TimeStamp = DateTime.Now,
                User = await _userManager.FindByEmailAsync(User.Identity.Name)
            });
            _db.MaintenanceIssues.Update(issue);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = issue.Id });
        }

        [Authorize(Roles = "Institution_Manager")]

        public async Task<IActionResult> Resolution(int id)
        {
            if (id == null)
            {
                return RedirectToAction("MaintenanceIssues", "Home");
            }
            var issue = await _db.MaintenanceIssues.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (issue == null)
            {
                return RedirectToAction("MaintenanceIssues", "Home");
            }
                ResolutionViewModel resVM = new ResolutionViewModel()
                {
                    MaintenanceIssue = issue,
                    Resolution = new ResolutionModel()
                };
                
            return View(resVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddResolution(string details, int id)
        {
            var issue = await _db.MaintenanceIssues.Where(n => n.Id == id).FirstOrDefaultAsync();
            issue.ResolutionComments.Add(new ResolutionModel
            {
                MaintenanceIssueId = id,
                DateResolved = DateTime.Now,
                User = await _userManager.FindByEmailAsync(User.Identity.Name),
                Details = details
            });
           
            issue.IsResolved = true;
            _db.MaintenanceIssues.Update(issue);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Resolution), new { id = issue.Id });
        }





        [Authorize(Roles = "Institution_Staff")]
        public async Task<IActionResult> CreateStaff()
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
        public async Task<IActionResult> CreateStaff(MaintenanceViewModel model)
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
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Institution_Staff")]

        public async Task<IActionResult> DetailsStaff(int id)
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
            var VM = new IssueViewModel();

            //Creates a list to populate with IssueViewModels
            //Loops through both the list of maintenance issues and general 
            var user = _db.Users.FirstOrDefault(i => i.Id == issue.UserId);
            var room = _db.Rooms.FirstOrDefault(i => i.Id == issue.RoomId);
            var asset = _db.Assets.FirstOrDefault(i => i.Id == issue.AssetId);
            if (room != null && asset != null)
            {
                IssueViewModel issueVM = new IssueViewModel()
                {
                    User = user,
                    MaintenanceIssues = issue,
                    Room = room,
                    Asset = asset
                };
                VM = issueVM;
            }

            return View(VM);
        }
    }
}
