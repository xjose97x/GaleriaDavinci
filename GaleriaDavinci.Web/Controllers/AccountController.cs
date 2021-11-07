using GaleriaDavinci.Controllers;
using GaleriaDavinci.Domain.Models;
using GaleriaDavinci.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = await _userManager.Users.Where(u => u.Email == model.Email).SingleOrDefaultAsync();
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña invalida");
                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: true);
            if(!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña invalida");
                return View(model);
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToLocal(returnUrl);
            }
            return RedirectToAction("Index", "Gallery");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityResult result = await _userManager.CreateAsync(new ApplicationUser(model.Email, model.FirstName, model.LastName), model.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Fallo el registro");
                return View(model);
            }
            ApplicationUser user = await _userManager.Users.Where(u => u.Email == model.Email).SingleOrDefaultAsync();
            await _userManager.AddToRoleAsync(user, SystemRoles.AUTHOR);
            await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: true);
            return RedirectToAction("Index", "Gallery");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
