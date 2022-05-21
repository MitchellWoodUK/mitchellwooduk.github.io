using Assignment2Project.Data;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment2Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<CustomUserModel> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<CustomUserModel> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Institution_Manager")]

        public async Task<IActionResult> MaintenanceIssues(string q)
        {
            if (q != null)
            {
                //Creates a new issueViewModel, finds the logged in user and uses the users institution to find that institutions maintenance issues and general issues.
                var loggedIn = await _userManager.GetUserAsync(User);
                var institution = await _db.Institutions.Where(x => x.Id == loggedIn.InstitutionId).FirstOrDefaultAsync();

                var maintentanceIssues = await _db.MaintenanceIssues.Where(x => x.InstitutionId == loggedIn.InstitutionId).ToListAsync();

                //Creates a list to populate with IssueViewModels
                var VMlist = new List<IssueViewModel>();
                //Loops through both the list of maintenance issues and general 
                foreach (var mIssue in maintentanceIssues)
                {
                    var user = _db.Users.FirstOrDefault(i => i.Id == mIssue.UserId);
                    var room = _db.Rooms.FirstOrDefault(i => i.Id == mIssue.RoomId);
                    var asset = _db.Assets.FirstOrDefault(i => i.Id == mIssue.AssetId);
                    var maintenance = _db.MaintenanceIssues.FirstOrDefault(i => i.Id == mIssue.Id);
                    if (room != null && asset != null && maintenance != null)
                    {
                        IssueViewModel issueVM = new IssueViewModel()
                        {
                            User = user,
                            MaintenanceIssues = maintenance,
                            Room = room,
                            Asset = asset
                        };
                        VMlist.Add(issueVM);
                    }
                }
                //Takes the list and only returns the values where the searched input is there.
                var list = VMlist.Where(n => n.User.UserName.ToLower().Contains(q.ToLower())).ToList();
                return View(list);
            }
            else
            {
                //Creates a new issueViewModel, finds the logged in user and uses the users institution to find that institutions maintenance issues and general issues.
                var loggedIn = await _userManager.GetUserAsync(User);
                var institution = await _db.Institutions.Where(x => x.Id == loggedIn.InstitutionId).FirstOrDefaultAsync();

                var maintentanceIssues = await _db.MaintenanceIssues.Where(x => x.InstitutionId == loggedIn.InstitutionId).ToListAsync();

                //Creates a list to populate with IssueViewModels
                var VMlist = new List<IssueViewModel>();
                //Loops through both the list of maintenance issues and general 
                foreach (var mIssue in maintentanceIssues)
                {
                    var user = _db.Users.FirstOrDefault(i => i.Id == mIssue.UserId);
                    var room = _db.Rooms.FirstOrDefault(i => i.Id == mIssue.RoomId);
                    var asset = _db.Assets.FirstOrDefault(i => i.Id == mIssue.AssetId);
                    var maintenance = _db.MaintenanceIssues.Where(n => n.IsResolved == false).FirstOrDefault(i => i.Id == mIssue.Id);
                    if (room != null && asset != null && maintenance != null)
                    {
                        IssueViewModel issueVM = new IssueViewModel()
                        {
                            User = user,
                            MaintenanceIssues = maintenance,
                            Room = room,
                            Asset = asset
                        };
                        VMlist.Add(issueVM);
                    }
                }
                return View(VMlist);
            }

    
        }
        [Authorize(Roles = "Institution_Manager")]

        public async Task<IActionResult> GeneralIssues(string q)
        {
            if (q != null)
            {
                //Creates a new issueViewModel, finds the logged in user and uses the users institution to find that institutions maintenance issues and general issues.
                var loggedIn = await _userManager.GetUserAsync(User);
                var institution = await _db.Institutions.Where(x => x.Id == loggedIn.InstitutionId).FirstOrDefaultAsync();
                var generalIssues = await _db.GeneralIssues.Where(x => x.InstitutionId == loggedIn.InstitutionId).ToListAsync();
                //Creates a list to populate with GeneralIssues
                var list = new List<GeneralIssueViewModel>();
                //Loops through both the list of maintenance issues and general 
                foreach (var gIssue in generalIssues)
                {
                    var user = _db.Users.FirstOrDefault(i => i.Id == gIssue.UserId);
                    var general = _db.GeneralIssues.FirstOrDefault(i => i.Id == gIssue.Id);
                    if (general != null)
                    {
                        GeneralIssueViewModel issueVM = new GeneralIssueViewModel()
                        {
                            User = user,
                            GeneralIssue = general
                        };
                        list.Add(issueVM);
                    }
                }
                var searchedlist = list.Where(n => n.User.UserName.ToLower().Contains(q.ToLower())).ToList();

                return View(searchedlist);
            }
            else
            {
                //Creates a new issueViewModel, finds the logged in user and uses the users institution to find that institutions maintenance issues and general issues.
                var loggedIn = await _userManager.GetUserAsync(User);
                var institution = await _db.Institutions.Where(x => x.Id == loggedIn.InstitutionId).FirstOrDefaultAsync();
                var generalIssues = await _db.GeneralIssues.Where(x => x.InstitutionId == loggedIn.InstitutionId).ToListAsync();
                //Creates a list to populate with GeneralIssues
                var list = new List<GeneralIssueViewModel>();
                //Loops through both the list of maintenance issues and general 
                foreach (var gIssue in generalIssues)
                {
                    var user = _db.Users.FirstOrDefault(i => i.Id == gIssue.UserId);
                    var general = _db.GeneralIssues.Where(n => n.IsResolved == false).FirstOrDefault(i => i.Id == gIssue.Id);

                    if (general != null)
                    {
                        GeneralIssueViewModel issueVM = new GeneralIssueViewModel()
                        {
                            User = user,
                            GeneralIssue = general
                        };
                        list.Add(issueVM);
                    }
                }
                return View(list);
            }
           
        }



    }
}