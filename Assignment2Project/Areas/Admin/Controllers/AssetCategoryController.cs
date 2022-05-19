using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2Project.Areas.Admin.Models;
using Assignment2Project.Data;

namespace Assignment2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssetCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AssetCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetCategories.ToListAsync());
        }

      

        // GET: Admin/AssetCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AssetCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AssetCategoryModel assetCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetCategoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetCategoryModel);
        }

        // GET: Admin/AssetCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssetCategories == null)
            {
                return NotFound();
            }

            var assetCategoryModel = await _context.AssetCategories.FindAsync(id);
            if (assetCategoryModel == null)
            {
                return NotFound();
            }
            return View(assetCategoryModel);
        }

        // POST: Admin/AssetCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AssetCategoryModel assetCategoryModel)
        {
            if (id != assetCategoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetCategoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetCategoryModelExists(assetCategoryModel.Id))
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
            return View(assetCategoryModel);
        }

        // GET: Admin/AssetCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssetCategories == null)
            {
                return NotFound();
            }

            var assetCategoryModel = await _context.AssetCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetCategoryModel == null)
            {
                return NotFound();
            }

            return View(assetCategoryModel);
        }

        // POST: Admin/AssetCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssetCategories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AssetCategoryModel'  is null.");
            }
            var assetCategoryModel = await _context.AssetCategories.FindAsync(id);
            if (assetCategoryModel != null)
            {
                _context.AssetCategories.Remove(assetCategoryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetCategoryModelExists(int id)
        {
          return (_context.AssetCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
