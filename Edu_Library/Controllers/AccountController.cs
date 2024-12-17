using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Edu_Library.Data;
using Edu_Library.Models;

namespace Edu_Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDB_Context _context;

        public AccountController(ApplicationDB_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Books");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string UsernameOrEmail, string Password, bool RememberMe)
        {
            var user = _context.User_tb
                .FirstOrDefault(u => (u.UserName == UsernameOrEmail || u.Email == UsernameOrEmail) && u.Password == Password);

            if (user == null)
            {
                ViewBag.ErrorMessage = "ชื่อผู้ใช้หรืออีเมล หรือรหัสผ่านไม่ถูกต้อง";
                return View();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (user.Role == "Admin")
            {
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Books");
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
