﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if(roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            if(id != null)
            {
                var role = await _roleManager.FindByIdAsync(id);
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}
