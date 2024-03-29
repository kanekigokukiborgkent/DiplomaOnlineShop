﻿using DiplomaOnlineShop.Controllers;
using DiplomaOnlineShop.Models;
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
            return View(products);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "CosProd");
            else
            {
                Products obj = new();
                obj = products.FirstOrDefault(u => u.Id == id);
                products.Remove(obj);
                return RedirectToAction("Index", "CosProd");
            }
        }
        [HttpGet]
        public IActionResult FormOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (products != null)
            {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    OrderProducts A = new OrderProducts();
                    List<OrderProducts> obj = new List<OrderProducts>();
                    foreach (var el in products)
                    {
                        A.ProductsId = el.Id;
                        A.OrderId = order.OrderId;
                    OrderProducts B = new OrderProducts { OrderId = A.OrderId, ProductsId = A.ProductsId };
                        db.orderProducts.Add(B);
                        db.SaveChanges();
                    }
                    products = new List<Products>();
                return RedirectToAction("Index", "CosProd");
            }
            return View(products);
        }   
    }
}
