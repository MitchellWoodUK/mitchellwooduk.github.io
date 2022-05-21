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

        public async Task<IActionResult> Index(string q)
        {
            if (q != null)
            {
                var rooms = await _db.Rooms.Include("Category").Where(n => n.Name.ToLower().Contains(q.ToLower())).Include("Institution").ToListAsync();
                return View(rooms);
            }
            else
            {
                var rooms = await _db.Rooms.Include("Category").Include("Institution").ToListAsync();
                return View(rooms);
            }

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
            var roomModel = await _db.Rooms.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }
            RoomViewModel roomViewModel = new RoomViewModel()
            {
                Room = roomModel,
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
        public async Task<IActionResult> Edit(RoomViewModel model)
        {
            if (model != null)
            {
                RoomModel roomModel = new RoomModel();
                roomModel.Name = model.Room.Name;
                roomModel.InstitutionId = model.Room.InstitutionId;
                roomModel.CategoryId = model.Room.CategoryId;

                _db.Rooms.Update(roomModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var room = await _db.Rooms.FindAsync(id);
            if (room == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _db.Remove(room);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
