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

        public async Task<IActionResult> Issues()
        {
            //Creates a new issueViewModel, finds the logged in user and uses the users institution to find that institutions maintenance issues and general issues.
            var loggedIn = await _userManager.GetUserAsync(User);
            var institution = await _db.Institutions.Where(x => x.Id == loggedIn.InstitutionId).FirstOrDefaultAsync();
            var maintentanceIssues = await _db.MaintenanceIssues.Where(x => x.InstitutionId == loggedIn.InstitutionId).ToListAsync();
            var generalIssues = await _db.GeneralIssues.Where(x => x.InstitutionId == loggedIn.InstitutionId).ToListAsync();
            var VMlist = new List<IssueViewModel>();
            foreach (var issue in maintentanceIssues)
            {
                var room = _db.Rooms.FirstOrDefault(i => i.Id == issue.RoomId);
                if (room != null)
                {
                    IssueViewModel issueVM = new IssueViewModel()
                    {
                        Institution = institution,
                        MaintenanceIssues = maintentanceIssues,
                        GeneralIssues = generalIssues,
                        Room = room
                    };
                    VMlist.Add(issueVM);
                }
                
            }
            return View(VMlist);





            /*
                var users = await _userManager.Users.ToListAsync();
            var VMlist = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var institution = _db.Institutions.FirstOrDefault(i => i.Id == user.InstitutionId);
                if (institution != null)
                {
                    var currentVM = new UserRolesViewModel()
                    {
                        User = user,
                        Roles = new List<string>(await _userManager.GetRolesAsync(user)),
                        Institution = institution
                    };
                    VMlist.Add(currentVM);
                }

            }
            return View(VMlist); 
              
             
             
             
             
              */
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}