using DiplomaOnlineShop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DiplomaOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db;

        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment appEnvironment;

        public HomeController(ProductContext context, ILogger<HomeController> logger, IWebHostEnvironment _appEnvironment)
        {
            db = context;
            _logger = logger;
            appEnvironment = _appEnvironment;
        }
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [HttpGet]
        public IActionResult Meniu_manager()
        {
            ViewModel obj = new ViewModel();
            obj.viewProducts = db.products.ToList();

            return View(obj);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            ViewModel obj = new ViewModel();
            obj.viewProducts = db.products.ToList();

            Products v = new Products();
            v = obj.viewProducts.FirstOrDefault(x => x.Id == id);
            return View(v);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Loghin()
        {
            ViewModel obj = new ViewModel();
            obj.viewAdminUsers = db.AdminUsers.ToList();
            return View(obj.viewAdminUsers[0]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Loghin(AdminUser ad)
        {
            if (ModelState.IsValid)
            {
                AdminUser user = await db.AdminUsers.FirstOrDefaultAsync(u => u.login == ad.login && u.password == ad.password);
                if (user != null)
                {
                    await Authenticate(ad.login);
                    return RedirectToAction("Index", "AdminUser"); 
                }
            }
            return RedirectToAction("Index", "AdminUser");
        }
    }
}
