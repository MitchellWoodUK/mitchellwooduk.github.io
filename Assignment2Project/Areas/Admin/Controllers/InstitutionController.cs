#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2Project.Data;
using Assignment2Project.Models;

namespace Assignment2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstitutionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Institution
        public async Task<IActionResult> Index()
        {
            return View(await _context.Institutions.ToListAsync());
        }

        // GET: Admin/Institution/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionModel = await _context.Institutions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institutionModel == null)
            {
                return NotFound();
            }

            return View(institutionModel);
        }

        // GET: Admin/Institution/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Institution/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,TelephoneNum")] InstitutionModel institutionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionModel);
        }

        // GET: Admin/Institution/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionModel = await _context.Institutions.FindAsync(id);
            if (institutionModel == null)
            {
                return NotFound();
            }
            return View(institutionModel);
        }

        // POST: Admin/Institution/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,TelephoneNum")] InstitutionModel institutionModel)
        {
            if (id != institutionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionModelExists(institutionModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(institutionModel);
        }

        // GET: Admin/Institution/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionModel = await _context.Institutions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institutionModel == null)
            {
                return NotFound();
            }

            return View(institutionModel);
        }

        // POST: Admin/Institution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institutionModel = await _context.Institutions.FindAsync(id);
            _context.Institutions.Remove(institutionModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionModelExists(int id)
        {
            return _context.Institutions.Any(e => e.Id == id);
        }
    }
}
