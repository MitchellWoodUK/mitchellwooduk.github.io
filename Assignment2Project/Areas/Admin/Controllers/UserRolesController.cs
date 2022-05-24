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
                //Creates a list of Users and an empty list of User roles view model.
                var users = await _userManager.Users.ToListAsync();
                var VMlist = new List<UserRolesViewModel>();
                //Loops through each user in the list
                foreach (var user in users)
                {
                    //Find the institution that is linked to the institution id of the user.
                    var institution = _db.Institutions.FirstOrDefault(i => i.Id == user.InstitutionId);
                    if (institution != null)
                    {
                        //Creates a user roles view model and then adds it to the list made earlier.
                        var currentVM = new UserRolesViewModel()
                        {
                            User = user,
                            Roles = new List<string>(await _userManager.GetRolesAsync(user)),
                            Institution = institution
                        };
                        VMlist.Add(currentVM);
                    }

                }
                //Returns the list of user roles view model to the view.
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
            //Finds the user that has the same id that is passed into the method.
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            //create a new list of manage user role view model.
            var viewModels = new List<ManageUserRoleViewModel>();
            //Loops through each role and assigns the value to a manage user role view model and then adds to the list
            //And finally returns the list to the view.
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
            //Find the user by the id, and creates a list of institutions from the database.
            var user = await _userManager.FindByIdAsync(id);
            var institution = await _db.Institutions.ToListAsync();
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            //Creates a new view model that inputs the user and a select list of institutions to the view.
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
                //Finds the user by the id.
                var user = await _userManager.FindByIdAsync(model[0].User.Id);
                if (user != null)
                {
                    //Finds the roles that is linked to the user and removes them from the roles.
                    var roles = await _userManager.GetRolesAsync(user);
                    var result = await _userManager.RemoveFromRolesAsync(user, roles);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("1", "Error Removing Roles.");
                        return View(model);
                    }
                    //Once the user has been removed from the roles, it now finds the new roles that have been selected and adds them to the user.
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
            //Finds the user from the id and removes them from the database.
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
