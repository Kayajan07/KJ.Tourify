using KJ.Tourify.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KJ.Tourify.WebUI.Models;
using KJ.Tourify.WebUI.Models.Entities;
using System.Security.Claims;

namespace KJ.Tourify.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    public class AuthController : Controller
    {
        private readonly TourifyDbContext _context;

        public AuthController(TourifyDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }


        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                if (!await _context
                    .Users
                    .AnyAsync(x =>
                        x.Username == model.Username &&
                        x.Password == model.Password))
                    return View(model);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, "MasterAdmin")
                };

                var identity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                var props = new AuthenticationProperties
                {
                    IssuedUtc = DateTimeOffset.UtcNow,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20),
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    props);

                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

    }
}
