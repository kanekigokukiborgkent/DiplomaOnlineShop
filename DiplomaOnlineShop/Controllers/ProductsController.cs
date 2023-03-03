using DiplomaOnlineShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DiplomaOnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        ProductContext db;

        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment appEnvironment;

        public ProductsController(ProductContext context, ILogger<HomeController> logger, IWebHostEnvironment _appEnvironment)
        {
            db = context;
            _logger = logger;
            appEnvironment = _appEnvironment;
        }

        public IActionResult Index()
        {
            var rez = db.products.ToList();
            return View(rez);
        }

        [HttpPost]// Adaugarea Produs in BD
        public async Task<IActionResult> Add(IFormFile uploadedFile, Products produs)
        {
            if (uploadedFile != null)
            {
                string path = "/img/Produse/Tablets/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                string way = "/img/Produse/Tablets/";

                Products file = new Products { Img = uploadedFile.FileName, Path = way };
                Products obj = new Products
                {
                    producător = produs.producător,
                    model = produs.model,
                    pret = produs.pret,
                    diagonala_ecranului = produs.diagonala_ecranului,
                    memorie_incorporată = produs.memorie_incorporată,
                    Img = file.Img,
                    Path = file.Path,
                    RAM = produs.RAM,
                    camera_din_spate = produs.camera_din_spate,
                    rezolutia_ecranului = produs.rezolutia_ecranului,
                    camera_frontala = produs.camera_frontala,
                    capacitatea_bateriei = produs.capacitatea_bateriei,
                    garanție = produs.garanție,
                    culoare = produs.culoare,
                    category = produs.category
                };
                db.products.Add(obj);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
         
        [HttpPost]
        public async Task<IActionResult> Modifica(IFormFile uploadedFile, Products produs, int id)
        {
                if (uploadedFile != null)
                {
                    string path = "/img/Produse/Tablets/" + uploadedFile.FileName;

                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    string way = "/img/Produse/Tablets/";

                    Products obj = new Products
                    {
                        producător = produs.producător,
                        model = produs.model,  
                        pret = produs.pret,
                        diagonala_ecranului = produs.diagonala_ecranului,
                        memorie_incorporată = produs.memorie_incorporată,
                        Img = uploadedFile.FileName,
                        Path = way,
                        RAM = produs.RAM,
                        camera_din_spate = produs.camera_din_spate,
                        rezolutia_ecranului = produs.rezolutia_ecranului,
                        camera_frontala = produs.camera_frontala,
                        capacitatea_bateriei = produs.capacitatea_bateriei,
                        garanție = produs.garanție,
                        culoare = produs.culoare,
                        category = produs.category
                    };
                    Products ob2 = db.products.Where(s => s.Id == produs.Id).FirstOrDefault();
                    db.products.Remove(ob2);
                    db.products.Add(obj);
                    db.SaveChanges();
                }
             return RedirectToAction("Index");
        }
         
        [HttpGet]
        public IActionResult Modifica(int? id)
        {
            if (id == null) return RedirectToAction("Index");
             ViewBag.ProdusId = id;
            Products obj = new Products();
            obj = db.products.FirstOrDefault(u => u.Id == id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewModel obj = new ViewModel();
            obj.viewProducts = db.products.ToList();
            Products A = new Products();
            A = obj.viewProducts.FirstOrDefault(x => x.Id == id);
            db.products.Remove(A);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            ViewModel obj = new ViewModel();
            obj.viewProducts = db.products.ToList();

            Products v = new Products();
            v = obj.viewProducts.FirstOrDefault(x => x.Id == id);
            return View(v);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
