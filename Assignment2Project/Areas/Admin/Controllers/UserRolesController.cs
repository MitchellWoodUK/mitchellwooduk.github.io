using Assignment2Project.Areas.Admin.Models;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment2Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomUserModel> _userManager;
        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<CustomUserModel> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Route("UserRoles")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var VMlist = new List<UserRolesViewModel>();
            foreach(var user in users)
            {
                var currentVM = new UserRolesViewModel()
                {
                    User = user,
                    Roles = new List<string>(await _userManager.GetRolesAsync(user))
                };
                VMlist.Add(currentVM);
            }
            return View(VMlist);
        }
    }
}
