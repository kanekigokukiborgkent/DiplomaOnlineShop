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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
