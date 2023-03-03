/*using DiplomaOnlineShop.Models;
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
    public class TelephonsController : Controller
    {
        ProductContext db;

        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment appEnvironment;

        public TelephonsController(ProductContext context, ILogger<HomeController> logger, IWebHostEnvironment _appEnvironment)
        {
            db = context;
            _logger = logger;
            appEnvironment = _appEnvironment;
        }

        public IActionResult Index()
        {
            var rez = db.telephones.ToList();
            return View(rez);
        }

        public IActionResult Details(int id)// Detaliile la un anumit produs
        {
            ViewModel obj = new ViewModel();
            obj.viewTelephones = db.telephones.ToList();

            Telephones v = new Telephones();
            v = obj.viewTelephones.FirstOrDefault(x => x.Id == id);
            return View(v);
        }


        [HttpPost]// Adaugarea Produs in BD
        public async Task<IActionResult> Add(IFormFile uploadedFile, Telephones produs)
        {
                if (uploadedFile != null)
                {
                    string path = "/img/Produse/Telephons/" + uploadedFile.FileName;
                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    string way = "/img/Produse/Telephons/";
                    Telephones file = new Telephones { Img = uploadedFile.FileName, Path = way };
                    Telephones obj = new Telephones
                    {
                        producător = produs.producător,
                        model = produs.model,
                        pret = produs.pret,
                        diagonala_ecranului = produs.diagonala_ecranului,
                        memorie_incorporată = produs.memorie_incorporată,
                        Img = file.Img,
                        Path = file.Path,
                        RAM = produs.RAM,
                        camera_principală = produs.camera_principală,
                        camera_frontala = produs.camera_frontala,
                        capacitatea_bateriei = produs.capacitatea_bateriei,
                        garanție = produs.garanție,
                        culoare = produs.culoare
                    };   
                    db.telephones.Add(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
        }
        [HttpPost]// Modificarea produs
        public async Task<IActionResult> Modifica(IFormFile uploadedFile, Telephones produs, int id)
        {

            if (uploadedFile != null)
            {
                string path = "/img/Produse/Telephons/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                string way = "/img/Produse/Telephons/";
                Telephones obj = new Telephones
                {
                    producător = produs.producător,
                    model = produs.model,
                    pret = produs.pret,
                    diagonala_ecranului = produs.diagonala_ecranului,
                    memorie_incorporată = produs.memorie_incorporată,
                    Img = uploadedFile.FileName,
                    Path = way,
                    RAM = produs.RAM,
                    camera_principală = produs.camera_principală,
                    camera_frontala = produs.camera_frontala,
                    capacitatea_bateriei = produs.capacitatea_bateriei,
                    garanție = produs.garanție,
                    culoare = produs.culoare
                };
                Telephones ob2 = db.telephones.Where(s => s.Id == produs.Id).FirstOrDefault();
                db.telephones.Remove(ob2);
                db.telephones.Add(obj);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modifica(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.ProdusId = id;
            Telephones obj = new Telephones();
            obj = db.telephones.FirstOrDefault(u => u.Id == id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewModel obj = new ViewModel();
            obj.viewTelephones = db.telephones.ToList();
            Telephones A = new Telephones();
            A = obj.viewTelephones.FirstOrDefault(x => x.Id == id);
            db.telephones.Remove(A);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
*/