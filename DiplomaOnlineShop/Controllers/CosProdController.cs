using DiplomaOnlineShop.Controllers;
using DiplomaOnlineShop.Models;
using DiplomaOnlineShop.ViewsModels;
/*using DiplomaOnlineShop.Security;
using DiplomaOnlineShop.ViewModels;*/
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.Controllers
{
    public class CosProdController : Controller
    {
        ProductContext db;

        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment appEnvironment;

        static public List<Telephones> telephones = new List<Telephones>();
        static public List<Tablets> tablets = new List<Tablets>();

        public CosProdController(ProductContext context, ILogger<HomeController> logger, IWebHostEnvironment _appEnvironment)
        {
            db = context;
            _logger = logger;
            appEnvironment = _appEnvironment;
        }

        public IActionResult Add(int? id, int typeProduct)
        {
            if (id == null) return RedirectToAction("Index", "Home");
            if (typeProduct == 1)
            {
                Telephones obj = new();
                obj = db.telephones.FirstOrDefault(u => u.Id == id);
                telephones.Add(obj);
            }
            else if (typeProduct == 0)
            {
                Tablets obj = new();
                obj = db.tablets.FirstOrDefault(u => u.Id == id);
                tablets.Add(obj);
            }

            return RedirectToAction("Index", "Home");
        }
         
       public IActionResult Index()
        {
            Device device = new Device();
            device.telephones = telephones;
            device.tablets = tablets;
            return View(device);
        }
        public IActionResult Delete(int? id, int typeProduct)
        {
            if (id == null) return RedirectToAction("Index", "CosProd");
            if (typeProduct == 0) {
                 Tablets obj = new();
                obj = tablets.FirstOrDefault(u => u.Id == id);
                tablets.Remove(obj);
                return RedirectToAction("Index", "CosProd");
            }
            else if (typeProduct == 1) {
                Telephones obj = new();
                obj = telephones.FirstOrDefault(u => u.Id == id);
                telephones.Remove(obj);
                return RedirectToAction("Index", "CosProd");
            }
            return RedirectToAction("Index", "CosProd");
        }
    }
}
