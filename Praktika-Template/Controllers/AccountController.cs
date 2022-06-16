
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Praktika_Template.Extention;
using Praktika_Template.Models;
using Praktika_Template.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praktika_Template.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                Email = register.Email,
                UserName = register.Username
            };

            if (register.IHaveReadIAccept == true)
            {
                IdentityResult result = await _userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Sertleri qebul edin");
                return View();
            }
            await _userManager.AddToRoleAsync(user, Role.User.ToString());
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction(nameof(Register));


        }
        public IActionResult Login()
        {
            return View();
        }


        //[HttpPost]
        //[AutoValidateAntiforgeryToken]

        //public async Task<IActionResult> Login(LoginVM login)
        //{
        //    AppUser user = await _userManager.FindByNameAsync(login.Username);
        //    if (user == null) return View();
        //    IList<string> roles = await _userManager.GetRolesAsync(user);
        //    string role = roles.FirstOrDefault(r => r == Role.User.ToString());
        //    if (role == null)
        //    {
        //        ModelState.AddModelError("", "Plase contact with admins");
        //        return View();
        //    }
        //    if (login.RememberMe)
        //    {
        //        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
        //        if (!result.Succeeded)
        //        {
        //            if (result.IsLockedOut)
        //            {
        //                ModelState.AddModelError("", "You have been dismissed for 5 minutes");
        //                return View();
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Username or Password is incorrect");
        //                return View();
        //            }
        //        }
        //    }
        //    return RedirectToAction("Home", "Home");

        //}
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Login(LoginVM login)
        {
            AppUser user = await _userManager.FindByNameAsync(login.Username);
            if (user == null) return View();
            IList <string> roles= await _userManager.GetRolesAsync(user);
           
            string role = roles.FirstOrDefault(r => r == Role.User.ToString());
            if (role == null)
            {
                ModelState.AddModelError("", "Plase contact with admins");
                return View();
            }
            if (login.RememberMe)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
                if (!result.Succeeded)

                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is incorrect");
                        return View();
                    }

                }
            }
            else
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);
                if (!result.Succeeded)

                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is incorrect");
                        return View();
                    }

                }
            }

            
            return RedirectToAction("Home", "Home");
        }
        public async Task CreateRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = Role.User.ToString() });
            await _roleManager.CreateAsync(new IdentityRole { Name = Role.Admin.ToString() });
            await _roleManager.CreateAsync(new IdentityRole { Name = Role.SuperAdmin.ToString() });
        }
    }
}

