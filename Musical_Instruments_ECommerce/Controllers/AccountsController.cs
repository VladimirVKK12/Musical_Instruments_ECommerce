using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Musical_Instruments_ECommerce.DbConnection;
using Musical_Instruments_ECommerce.Models;
using Musical_Instruments_ECommerce.ViewModel.AccountVM;
using System.Security.Claims;

namespace Musical_Instruments_ECommerce.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext db;
        public AccountsController(AppDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Accounts accounts)
        {
            if (db.Accounts.Any(x=>x.Username == accounts.Username))
            {
                TempData["Username"] = "This username already exist please choose another";
            }
            else if (db.Accounts.Any(x => x.Email== accounts.Email))
            {
                TempData["Email"] = "This email already exist please choose another";
            }

            if (!db.Accounts.Any())
            {
                accounts.Role = "Admin";
            }
            else
            {
                accounts.Role = "User";
            }

            db.Accounts.Add(accounts);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = db.Accounts.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                TempData["WrongPassOrEmail"] = "Wrong Password or Email";
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),authProperties);


            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
