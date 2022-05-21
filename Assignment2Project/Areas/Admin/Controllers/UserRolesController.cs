using Assignment2Project.Areas.Admin.Models;
using Assignment2Project.Data;
using Assignment2Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment2Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Estates_Admin")]
    [Area("Admin")]
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomUserModel> _userManager;
        private readonly ApplicationDbContext _db;
        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<CustomUserModel> userManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public async Task<IActionResult> Index(string q)
        {
            if(q != null)
            {
                var users = await _userManager.Users.ToListAsync();
                var VMlist = new List<UserRolesViewModel>();

                foreach (var user in users)
                {
                    var institution = _db.Institutions.FirstOrDefault(i => i.Id == user.InstitutionId);
                    if (institution != null)
                    {
                        var currentVM = new UserRolesViewModel()
                        {
                            User = user,
                            Roles = new List<string>(await _userManager.GetRolesAsync(user)),
                            Institution = institution
                        };
                        VMlist.Add(currentVM);
                    }

                }
                var list = VMlist.Where(n =>n.User.UserName.ToLower().Contains(q.ToLower())).ToList();
                return View(list);
            }
            else
            {
                var users = await _userManager.Users.ToListAsync();
                var VMlist = new List<UserRolesViewModel>();

                foreach (var user in users)
                {
                    var institution = _db.Institutions.FirstOrDefault(i => i.Id == user.InstitutionId);
                    if (institution != null)
                    {
                        var currentVM = new UserRolesViewModel()
                        {
                            User = user,
                            Roles = new List<string>(await _userManager.GetRolesAsync(user)),
                            Institution = institution
                        };
                        VMlist.Add(currentVM);
                    }

                }
                return View(VMlist);
            }
         
        }


        //GET
        public async Task<IActionResult> Manage(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var viewModels = new List<ManageUserRoleViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var vm = new ManageUserRoleViewModel();
                vm.User = user;
                vm.Role = role;
                vm.IsInRole = await _userManager.IsInRoleAsync(user, role.Name);
                viewModels.Add(vm);
            }
            return View(viewModels);
        }

        //GET
        public async Task<IActionResult> ManageInstitution(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var institution = await _db.Institutions.ToListAsync();

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            ManageInstitutionViewModel viewModels = new ManageInstitutionViewModel()
            {
                User = user,
                InstitutionList = _db.Institutions.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            return View(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRoleViewModel> model)
        {
            if (model != null && model.Count >= 1)
            {
                var user = await _userManager.FindByIdAsync(model[0].User.Id);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var result = await _userManager.RemoveFromRolesAsync(user, roles);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("1", "Error Removing Roles.");
                        return View(model);
                    }
                    result = await _userManager.AddToRolesAsync(user, model.Where(x => x.IsInRole).Select(y => y.Role.Name));
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("3", "Error Adding Roles.");
                        return View(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("2", "User Not Found.");
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Manage");
            }
        }

        //Post function to update the institution for the user.
        [HttpPost]
        public async Task<IActionResult> ManageInstitution(ManageInstitutionViewModel model)
        {
            if (model != null)
            {
                //Finds the user from the model.
                var user = await _userManager.FindByIdAsync(model.User.Id);

                if (user != null)
                {
                    //Changes the institution Id to the new selected option.
                    user.InstitutionId = model.User.InstitutionId;
                    //Updates the database.
                    _db.Users.Update(user);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Manage");
                }
                else
                {
                    return RedirectToAction("Manage");
                }
            }
            return RedirectToAction("Manage");

        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
