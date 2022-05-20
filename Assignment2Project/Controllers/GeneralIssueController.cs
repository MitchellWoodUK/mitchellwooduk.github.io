using Assignment2Project.Data;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2Project.Controllers
{
    public class GeneralIssueController : Controller
    {
        public readonly ApplicationDbContext _db;
        public readonly UserManager<CustomUserModel> _userManager;

        public GeneralIssueController(ApplicationDbContext db, UserManager<CustomUserModel> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            //Passes an empty general issue model into the create view.
            GeneralIssueModel model = new GeneralIssueModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GeneralIssueModel model)
        {
            //Returns the data needed to create a general issue from the create view.
            var loggedIn = await _userManager.GetUserAsync(User);

            if (model != null)
            {
                GeneralIssueModel issueModel = new GeneralIssueModel();
                issueModel.DateRaised = DateTime.Now;
                issueModel.UserId = loggedIn.Id;
                issueModel.Details = model.Details;
                issueModel.IsResolved = false;
                issueModel.InstitutionId = loggedIn.InstitutionId;
                await _db.GeneralIssues.AddAsync(issueModel);
                await _db.SaveChangesAsync();
                //Redirects to the Issues action in the Home controller.
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
