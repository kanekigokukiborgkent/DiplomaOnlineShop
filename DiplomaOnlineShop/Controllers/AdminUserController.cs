using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DiplomaOnlineShop.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System;
using Magazin.Models;

namespace Magazin.Controllers
{
    public class AdminUserController : Controller
    {

        ProductContext db;
        private readonly ILogger<AdminUserController> _logger;
        IWebHostEnvironment appEnvironment;
        public AdminUserController(ProductContext context, ILogger<AdminUserController> logger, IWebHostEnvironment _appEnvironment)
        {
            db = context;
            _logger = logger;
            appEnvironment = _appEnvironment;
        }
        [HttpGet]
        [Authorize]
        public IActionResult AdminIndex(string searchString)
        {
            ViewModel obj = new ViewModel();
            obj.viewProducts = db.products.ToList();

            if (obj.viewProducts == null)
            {
                return Problem("Products is null.");
            }
            var productss = from m in obj.viewProducts
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                productss = productss.Where(s => s.model!.Contains(searchString));
            }
            return View(productss.ToList());
        }
        public IActionResult Details(int id)
        {
            ViewModel obj = new ViewModel();
            obj.viewProducts = db.products.ToList();
            Products v = new Products();
            v = obj.viewProducts.FirstOrDefault(x => x.Id == id);
            return View(v);
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
            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
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
            return RedirectToAction("AdminIndex");
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
            return RedirectToAction("AdminIndex");
        }
        [HttpGet]
        public IActionResult Modifica(int? id)
        {
            if (id == null) return RedirectToAction("AdminIndex");
            ViewBag.ProdusId = id;
            Products obj = new Products();
            obj = db.products.FirstOrDefault(u => u.Id == id);
            return View(obj);
        }
        public IActionResult AddOrder(int? id, int typeProduct)
        {
            if (id == null) return RedirectToAction("Index", "Home");
                Products obj = new();
                obj = db.products.FirstOrDefault(u => u.Id == id);
                db.products.Add(obj);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Orders()
        {
            IEnumerable<ProdOrder> obj = new List<ProdOrder>();
            obj = join();
            return View(obj);
        }
        public IActionResult Index()
        {
            ViewModel viewModels = new ViewModel();
            viewModels.viewProducts = db.products.ToList();
            return View(viewModels);
        }
        public List<ProdOrder> join()
        {
            List<ProductOrder> first = new List<ProductOrder>();
            first = db.orderProducts.Join(db.products,
                u => u.ProductsId,
                p => p.Id,
                (u, p) => new ProductOrder
                { Id = u.Id, OrderId = u.OrderId, Order = u.Order, Products = p.model, Path = p.Path, Pret = p.pret }
                ).ToList();
            // db.SaveChanges();
            List<ProdOrder> last = new List<ProdOrder>();
            last = first.Join(db.Orders,
                p => p.OrderId,
                u => u.OrderId,
                (p, u) => new ProdOrder
                {
                    Id = p.Id,
                    Produs = p.Products,
                    Order = u.Name,
                   Strada = u.Strada,
                   Oras = u.Oraș,
                   Numar_Telefon = u.Numar_de_telefon,
                   Pret = p.Pret
                }
                ).ToList();
            return last;
        }
    } 
}