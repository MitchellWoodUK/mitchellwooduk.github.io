﻿using Assignment2Project.Data;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Authorize(Roles = "Institution_Manager")]

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

        [Authorize(Roles = "Institution_Manager")]

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("GeneralIssues", "Home");
            }
            var issue = await _db.GeneralIssues.Where(x => x.Id == id).FirstOrDefaultAsync();
            issue.GeneralComments = await _db.GeneralComments.Where(x => x.GeneralIssueId == issue.Id).Include("User").OrderByDescending(x => x.TimeStamp).ToListAsync();
            if (issue == null)
            {
                return RedirectToAction("GeneralIssues", "Home");
            }
            var VM = new GeneralIssueViewModel();

            //Creates a list to populate with IssueViewModels
            //Loops through both the list of maintenance issues and general 
            var user = _db.Users.FirstOrDefault(i => i.Id == issue.UserId);
            if (user != null)
            {
                GeneralIssueViewModel issueVM = new GeneralIssueViewModel()
                {
                    User = user,
                    GeneralIssue = issue
                };
                VM = issueVM;
            }

            return View(VM);
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(string comment, int id)
        {
            //Finds the issue from the database where the id is the same and then adds a comment to the list of comments in the model.
            var issue = await _db.GeneralIssues.Where(x => x.Id == id).FirstOrDefaultAsync();
            issue.GeneralComments.Add(new GeneralCommentModel
            {
                Comment = comment,
                GeneralIssueId = id,
                TimeStamp = DateTime.Now,
                User = await _userManager.FindByEmailAsync(User.Identity.Name)
            });
            _db.GeneralIssues.Update(issue);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = issue.Id });
        }

        [Authorize(Roles = "Institution_Manager")]

        public async Task<IActionResult> Resolution(int id)
        {
            if (id == null)
            {
                return RedirectToAction("GeneralIssues", "Home");
            }
            //Finds the correct issue from the database using the id.
            var issue = await _db.GeneralIssues.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (issue == null)
            {
                return RedirectToAction("GeneralIssues", "Home");
            }
            //Creates a new view model and adds the issue and a new resolution model.
            GeneralResolutionViewModel resVM = new GeneralResolutionViewModel()
            {
                GeneralIssue = issue,
                Resolution = new ResolutionModel()
            };
            //Returns the view model.
            return View(resVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddResolution(string details, int id)
        {
            //finds the issue from the database using the id.
            var issue = await _db.GeneralIssues.Where(n => n.Id == id).FirstOrDefaultAsync();
            //Adds a resolution comment to the issue that was found and updates it in the database.
            issue.ResolutionComments.Add(new GeneralResolutionModel
            {
                GeneralIssueId = id,
                DateResolved = DateTime.Now,
                User = await _userManager.FindByEmailAsync(User.Identity.Name),
                Details = details
            });

            issue.IsResolved = true;
            _db.GeneralIssues.Update(issue);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Resolution), new { id = issue.Id });
        }

        [Authorize(Roles = "Institution_Staff")]

        public IActionResult CreateStaff()
        {
            //Passes an empty general issue model into the create view.
            GeneralIssueModel model = new GeneralIssueModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(GeneralIssueModel model)
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

        [Authorize(Roles = "Institution_Manager")]
        public async Task<IActionResult> DetailsStaff(int id)
        {
            if (id == null)
            {
                return RedirectToAction("GeneralIssues", "Home");
            }
            var issue = await _db.GeneralIssues.Where(x => x.Id == id).FirstOrDefaultAsync();
            issue.GeneralComments = await _db.GeneralComments.Where(x => x.GeneralIssueId == issue.Id).Include("User").OrderByDescending(x => x.TimeStamp).ToListAsync();
            if (issue == null)
            {
                return RedirectToAction("GeneralIssues", "Home");
            }
            var VM = new GeneralIssueViewModel();

            //Creates a list to populate with IssueViewModels
            //Loops through both the list of maintenance issues and general 
            var user = _db.Users.FirstOrDefault(i => i.Id == issue.UserId);
            if (user != null)
            {
                GeneralIssueViewModel issueVM = new GeneralIssueViewModel()
                {
                    User = user,
                    GeneralIssue = issue
                };
                VM = issueVM;
            }
            return View(VM);
        }
    }
}
