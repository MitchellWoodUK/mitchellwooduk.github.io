using Assignment2Project.Areas.Admin.Models;
using Assignment2Project.Data;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment2Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Estates_Admin")]
    [Area("Admin")]
    public class AssetController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AssetController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string q)
        {
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
        
        public IActionResult Create()
        {
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
            var asset = await _db.Assets.FindAsync(id);
            if (asset == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _db.Remove(asset);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
