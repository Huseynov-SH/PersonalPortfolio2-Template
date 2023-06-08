using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Final_Project.Helpers;
using Asp.Net_Final_Project.Models;
using Asp.Net_Final_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Final_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]

    public class UserController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task RoleSeed()
        {
            if (!await _roleManager.RoleExistsAsync(UR.Roles.Admin.ToString()))
                await _roleManager.CreateAsync(new IdentityRole(UR.Roles.Admin.ToString()));
            if (!await _roleManager.RoleExistsAsync(UR.Roles.Manager.ToString()))
                await _roleManager.CreateAsync(new IdentityRole(UR.Roles.Manager.ToString()));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserCreate(UserCreateVM createUser)
        {
            if (!ModelState.IsValid) return View(createUser);

            AppUser appUser = new AppUser
            {
                Name = createUser.Name,
                Surname = createUser.Surname,
                Email = createUser.Email,
                UserName = createUser.Username,
                Blocked = false
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, createUser.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(createUser);
            }
            await _userManager.AddToRoleAsync(appUser, UR.Roles.Manager.ToString());
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }
        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginUser)
        {
            if (!ModelState.IsValid) return View(loginUser);
            AppUser user = await _userManager.FindByEmailAsync(loginUser.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password is wrong");
                return View(loginUser);
            }

            if (user.Blocked == true)
            {
                ModelState.AddModelError("", "You are blocked by admin");
                return View(loginUser);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginUser.Password, loginUser.RememberMe, true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is wrong");
                return View(loginUser);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [Authorize(Roles = UR.AdminReole)]
        public async Task<IActionResult> ManagerUser()
        {
            IList<AppUser> managerUsers = await _userManager.GetUsersInRoleAsync(UR.ManagerRole);
            return View(managerUsers);
        }

        public async Task<IActionResult> MakeAdmin(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user == null) return NotFound();

            await _userManager.RemoveFromRoleAsync(user, UR.ManagerRole);
            await _userManager.AddToRoleAsync(user, UR.AdminReole);

            return RedirectToAction(nameof(ManagerUser));
        }

        public async Task<IActionResult> BlockUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user == null) return NotFound();

            user.Blocked = true;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(ManagerUser));

        }

        public async Task<IActionResult> BlockedUser(string id)
        {
            IList<AppUser> managerUsers = await _userManager.GetUsersInRoleAsync(UR.ManagerRole);
            return View(managerUsers);
        }

        public async Task<IActionResult> UnblockManager(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user == null) return NotFound();

            user.Blocked = false;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(ManagerUser));
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(ManagerUser));
        }
    }
}