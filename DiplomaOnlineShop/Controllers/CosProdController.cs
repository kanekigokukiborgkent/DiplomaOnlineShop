using DiplomaOnlineShop.Controllers;
using DiplomaOnlineShop.Models;
using DiplomaOnlineShop.ViewModels;
using Magazin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Magazin.Controllers
{
    public class CosProdController : Controller
    {
        ProductContext db;

        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment appEnvironment;

        static public List<Products> products = new List<Products>();

        public CosProdController(ProductContext context, ILogger<HomeController> logger, IWebHostEnvironment _appEnvironment)
        {
            db = context;
            _logger = logger;
            appEnvironment = _appEnvironment;
        }

        public IActionResult Add(int? id, int typeProduct)
        {
            if (id == null) return RedirectToAction("Index", "Home");
            if (typeProduct == 0)
            {
                Products obj = new();
                obj = db.products.FirstOrDefault(u => u.Id == id);
                products.Add(obj);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            ViewModels viewModels = new ViewModels();
            viewModels.ViewProducts = products;
            return View(viewModels);
        }
        public IActionResult Delete(int? id, int typeProduct)
        {
            if (id == null) return RedirectToAction("Index", "CosProd");
            if (typeProduct == 0)
            {
                Products obj = new();
                obj = products.FirstOrDefault(u => u.Id == id);
                products.Remove(obj);
                return RedirectToAction("Index", "CosProd");
            }
            return RedirectToAction("Index", "CosProd");
        }


        [HttpGet]
        public IActionResult FormOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FormOrder(Order order)
        {
            if (products != null)
            {
                 
                    db.Orders.Add(order);
                    db.SaveChanges();

                    ProductOrder A = new ProductOrder();
                    List<ProductOrder> obj = new List<ProductOrder>();


                    foreach (var el in products)
                    {

                        A.ProductsId = el.Id;
                        A.OrderId = order.OrderId;
                        ProductOrder B = new ProductOrder { OrderId = A.OrderId, ProductsId = A.ProductsId };
                        db.ProductOrders.Add(B);
                        db.SaveChanges();
                    }

                products = new List<Products>();

                    return RedirectToAction("Index", "Home");
                }
            
            return View(products);
        }
    }
}
