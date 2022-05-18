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

        public async Task<IActionResult> Index()
        {
            var assets = await _db.Assets.Include("Category").Include("Room").ToListAsync();
            return View(assets);
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
                RoomList = _db.Rooms.Where(x => x.InstitutionId == ).Select(c => new SelectListItem
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





    }
}
