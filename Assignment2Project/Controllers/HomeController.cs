using Assignment2Project.Data;
using Assignment2Project.Models;
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

        public async Task<IActionResult> MaintenanceIssues()
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
                var room = _db.Rooms.FirstOrDefault(i => i.Id == mIssue.RoomId);
                var asset = _db.Assets.FirstOrDefault(i => i.Id == mIssue.AssetId);
                var maintenance = _db.MaintenanceIssues.FirstOrDefault(i => i.Id == mIssue.Id);
                if (room != null && asset != null && maintenance != null)
                {
                    IssueViewModel issueVM = new IssueViewModel()
                    {
                        MaintenanceIssues = maintenance,
                        Room = room,
                        Asset = asset
                    };
                    VMlist.Add(issueVM);
                }
            }
            return View(VMlist);
        }

        public async Task<IActionResult> GeneralIssues()
        {
            //Creates a new issueViewModel, finds the logged in user and uses the users institution to find that institutions maintenance issues and general issues.
            var loggedIn = await _userManager.GetUserAsync(User);
            var institution = await _db.Institutions.Where(x => x.Id == loggedIn.InstitutionId).FirstOrDefaultAsync();
            var generalIssues = await _db.GeneralIssues.Where(x => x.InstitutionId == loggedIn.InstitutionId).ToListAsync();
            //Creates a list to populate with GeneralIssues
            var list = new List<GeneralIssueModel>();
            //Loops through both the list of maintenance issues and general 
            foreach (var gIssue in generalIssues)
            {
                var general = _db.GeneralIssues.FirstOrDefault(i => i.Id == gIssue.Id);
                if(general != null)
                {
                    list.Add(general);
                }
            }
            return View(list);
        }


 
    }
}