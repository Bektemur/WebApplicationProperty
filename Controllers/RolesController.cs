using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebApplicationProperty.Models;
using Microsoft.AspNetCore.Authorization;
using WebApplicationProperty.Data;
using System;
using System.Text;

namespace WebApplicationProperty.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Manager)]
    public class RolesController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RolesController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index(int skip = 0, int take = 10) => 
            View(_roleManager.Roles
                .OrderBy(x => x.CreatedDate)
                .Skip(skip)
                .Take(take)
                .ToList());

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name, string description = "")
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole(name)
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.UtcNow,
                    Description = description
                });
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList(string email, int skip = 0, int take = 10) =>
            View(_userManager.Users
                .Where(x => string.IsNullOrWhiteSpace(email) || x.Email.Equals(email))
                .Skip(skip)
                .Take(take)
                .OrderByDescending(x => x.Id)
                .ToList());

        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                //await _signInManager.RefreshSignInAsync(user);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                _ = await _userManager.DeleteAsync(user);
                return RedirectToAction("UserList");
            }

            return NotFound();
        }

        [HttpPost]
        public FileResult Export()
        {
            StringBuilder sb = new StringBuilder();
            var users = new List<string>() { string.Join(",", "Id", "CreatedDate", "UserName", "FirstName", "LastName", "Email", "PhoneNumber") };
            var query = _userManager.Users.Select(x => string.Join(",", x.Id, x.CreatedDate.ToString("G"), x.UserName, x.FirstName, x.LastName, x.Email, x.PhoneNumber)).ToList();
            users.AddRange(query);
            foreach (var user in users)
            {
                sb.Append(user + "\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "AllUsers.csv");
        }
    }
}