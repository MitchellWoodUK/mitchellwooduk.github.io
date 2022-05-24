using Assignment2Project.Areas.Admin.Models;
using Assignment2Project.Data;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssetController : Controller
    {
        private readonly ApplicationDbContext _db;
        public readonly UserManager<CustomUserModel> _userManager;

        public AssetController(ApplicationDbContext db, UserManager<CustomUserModel> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize(Roles = "Estates_Admin")]

        public async Task<IActionResult> Index(string q)
        {
            //Return a list of Assets, including the categories and rooms connecting to them.
            //Checks against the search value if q is not null.
            if(q != null)
            {
                var assets = await _db.Assets.Where(n => n.Name.ToLower().Contains(q.ToLower())).Include("Category").Include("Room").ToListAsync();
                return View(assets);
            }
            else
            {
                var assets = await _db.Assets.Include("Category").Include("Room").ToListAsync();
                return View(assets);
            }
           
        }

        [Authorize(Roles = "Estates_Admin")]

        public IActionResult Create()
        {
            //Returns a view model containing a select list item of the institutions, rooms, and asset categories.
            AssetViewModel assetViewModel = new AssetViewModel()
            {
                Asset = new AssetModel(),
                InstitutionList = _db.Institutions.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                RoomList = _db.Rooms.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                CategoryList = _db.AssetCategories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(assetViewModel);
        }

        [HttpGet]
        public IEnumerable<SelectListItem> GetRooms(int selectedInstitution)
        {
            //If the passed insitution is not null then made a list of rooms from the database
            //where the institution is the same as the id passed to the method.
            //Return the select list of rooms.
            if(selectedInstitution != null)
            {
                var RoomList = _db.Rooms
                    .Where(n => n.Institution.Id == selectedInstitution)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name
                        }).ToList();
                return new SelectList(RoomList, "Value", "Text");
            }
            return null;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AssetViewModel model)
        {
            //If the model is not null then pull in all the necessary values from model to populate an AssetModel and save it to the database.
            if (model != null)
            {
                AssetModel assetModel = new AssetModel();
                assetModel.Name = model.Asset.Name;
                assetModel.RoomId = model.SelectedRoom;
                assetModel.CategoryId = model.Asset.CategoryId;

                await _db.Assets.AddAsync(assetModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assetModel = await _db.Assets.FindAsync(id);
            if (assetModel == null)
            {
                return NotFound();
            }
            //Returns select list items to the view for editing the object.
            AssetViewModel assetViewModel = new AssetViewModel()
            {
                Asset = assetModel,
                InstitutionList = _db.Institutions.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                RoomList = _db.Rooms.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                CategoryList = _db.AssetCategories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            return View(assetViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AssetViewModel model)
        {
            //If the model is not null then pull in all the necessary values from model to populate an AssetModel and update it to the database.

            if (model != null)
            {
                AssetModel assetModel = new AssetModel();
                assetModel.Name = model.Asset.Name;
                assetModel.RoomId = model.SelectedRoom;
                assetModel.CategoryId = model.Asset.CategoryId;

                _db.Assets.Update(assetModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            //Find the asset based on the id passed to the method and then remove the asset from the database and save the changes.
            var asset = await _db.Assets.FindAsync(id);
            if (asset == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _db.Remove(asset);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Institution_Manager")]
        public async Task<IActionResult> IndexManager(string q)
        {
            //Index method for the manager role.
            var loggedIn = await _userManager.GetUserAsync(User);

            if (q != null)
            {
                var assets = await _db.Assets.Where(n => n.Room.InstitutionId == loggedIn.InstitutionId).Where(n => n.Name.ToLower().Contains(q.ToLower())).Include("Category").Include("Room").ToListAsync();
                return View(assets);
            }
            else
            {
                var assets = await _db.Assets.Where(n => n.Room.InstitutionId == loggedIn.InstitutionId).Include("Category").Include("Room").ToListAsync();
                return View(assets);
            }

        }

        [Authorize(Roles = "Institution_Manager")]
        public async Task<IActionResult> CreateManager()
        {
            //create method for the manager role.
            var loggedIn =  await _userManager.GetUserAsync(User);

            AssetViewModel assetViewModel = new AssetViewModel()
            {
                Asset = new AssetModel(),
                InstitutionList = _db.Institutions.Where(n => n.Id == loggedIn.InstitutionId).Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                RoomList = _db.Rooms.Where(n => n.InstitutionId == loggedIn.InstitutionId).Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                CategoryList = _db.AssetCategories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(assetViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateManager(AssetViewModel model)
        {
            //create post method for the manager role.
            if (model != null)
            {
                AssetModel assetModel = new AssetModel();
                assetModel.Name = model.Asset.Name;
                assetModel.RoomId = model.SelectedRoom;
                assetModel.CategoryId = model.Asset.CategoryId;

                await _db.Assets.AddAsync(assetModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(IndexManager));
            }
            return RedirectToAction(nameof(IndexManager));

        }

        [Authorize(Roles = "Institution_Staff")]
        public async Task<IActionResult> IndexStaff(string q)
        {
            //index method for the staff role.
            var loggedIn = await _userManager.GetUserAsync(User);

            if (q != null)
            {
                var assets = await _db.Assets.Where(n => n.Room.InstitutionId == loggedIn.InstitutionId).Where(n => n.Name.ToLower().Contains(q.ToLower())).Include("Category").Include("Room").ToListAsync();
                return View(assets);
            }
            else
            {
                var assets = await _db.Assets.Where(n => n.Room.InstitutionId == loggedIn.InstitutionId).Include("Category").Include("Room").ToListAsync();
                return View(assets);
            }
        }
    }
}
