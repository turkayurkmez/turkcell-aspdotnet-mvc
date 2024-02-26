using eshop.MVC.Models;
using eshop.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eshop.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? gidilecekSayfa)
        {
            ViewBag.ReturnUrl = gidilecekSayfa;
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel user, string? gidilecekSayfa)
        {
            if (ModelState.IsValid)
            {
                var existingUser = userService.ValidateUser(user.UserName, user.Password);
                if (existingUser != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, existingUser.Name),
                        new Claim(ClaimTypes.Email, existingUser.Email),
                        new Claim(ClaimTypes.Role,existingUser.Role)

                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(principal);
                    if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                    {
                        return Redirect(gidilecekSayfa);
                    }
                    return Redirect("/");

                }
                ModelState.AddModelError("login", "Kullanıcı adı veya şife yanlış");

            }
            return View();
        }
    }
}
