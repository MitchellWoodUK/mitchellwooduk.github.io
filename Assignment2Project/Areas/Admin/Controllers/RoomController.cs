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
            var rooms = await _db.Rooms.Include("Category").Include("Institution").ToListAsync();
            return View(rooms);
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
                }),
                InstitutionList = _db.Institutions.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(roomViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomViewModel model)
        {
            if (model != null)
            {
                RoomModel roomModel = new RoomModel();
                roomModel.Name = model.Room.Name;
                roomModel.InstitutionId = model.Room.InstitutionId;
                roomModel.CategoryId = model.Room.CategoryId;
                await _db.Rooms.AddAsync(roomModel);
                await _db.SaveChangesAsync();
                return View(nameof(Index));
            }
            return View(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var roomModel = await _db.Rooms.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);
        }


    }
}
