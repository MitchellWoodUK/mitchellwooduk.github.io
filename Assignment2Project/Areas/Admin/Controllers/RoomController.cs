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
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RoomController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Rooms.ToListAsync());
        }

        public IActionResult Create()
        {
            RoomViewModel roomViewModel = new RoomViewModel()
            {
                Room = new RoomModel(),
                CategoryList = _db.RoomCategories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(roomViewModel);
        }







    }
}
