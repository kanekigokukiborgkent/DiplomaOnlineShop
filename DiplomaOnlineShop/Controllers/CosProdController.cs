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
        /* [HttpGet]
         public IActionResult Buy()
         {

             return View();
         }
         [HttpPost]
         public IActionResult Show(Order order)
         {
             if (produse != null)
             {
                 if (securitOrder(order))
                 {
                     db.Orders.Add(order);
                     db.SaveChanges();

                     OrderProdus A = new OrderProdus();
                     List<OrderProdus> obj = new List<OrderProdus>();


                     foreach (var el in produse)
                     {

                         A.ProdusId = el.Id;
                         A.OrderId = order.OrderId;
                         OrderProdus B = new OrderProdus { OrderId = A.OrderId, ProdusId = A.ProdusId };
                         db.OrdersProdus.Add(B);
                         db.SaveChanges();
                         TempData["Message"] = order.User;
                     }

                     produse = new List<Produs>();

                     return RedirectToAction("Thanks");
                 }
             }
             return View(produse);
         }

         public bool securitOrder(Order order)
         {
             NotNull obj = new NotNull();
             string k = obj.securitOrder(order);
             if (k.Contains("1"))
                 ViewBag.ErrUser = obj.errorMessage;
             if (k.Contains("2"))
                 ViewBag.ErrAdress = obj.errorMessage;
             if (k.Contains("3"))
                 ViewBag.ErrPhone = obj.errorMessage;
             if (k == "")
                 return true;
             return false;

         }

         public IActionResult Thanks()
         {

             return View();
         }*/
    }
}
