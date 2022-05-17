using Assignment2Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
