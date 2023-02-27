﻿using DiplomaOnlineShop.Models;
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
    public class TabletsController : Controller
    {
        ProductContext db;

        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment appEnvironment;

        public TabletsController(ProductContext context, ILogger<HomeController> logger, IWebHostEnvironment _appEnvironment)
        {
            db = context;
            _logger = logger;
            appEnvironment = _appEnvironment;
        }

        public IActionResult Index()
        {
            var rez = db.tablets.ToList();
            return View(rez);
        }

        [HttpPost]// Adaugarea Produs in BD
        public async Task<IActionResult> Add(IFormFile uploadedFile, Tablets produs)
        {
            if (uploadedFile != null)
            {
                string path = "/img/Produse/Tablets/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                string way = "/img/Produse/Tablets/";

                Tablets file = new Tablets { Img = uploadedFile.FileName, Path = way };
                Tablets obj = new Tablets
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
                    materialul_carcasei = produs.materialul_carcasei,
                    dimensiuni = produs.dimensiuni,
                    capacitatea_bateriei = produs.capacitatea_bateriei,
                    greutate = produs.greutate,
                    garanție = produs.garanție,
                    culoare = produs.culoare
                };
                db.tablets.Add(obj);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
         
        [HttpPost]// Modificarea produs
        public async Task<IActionResult> Modifica(IFormFile uploadedFile, Tablets produs, int id)
        {
                if (uploadedFile != null)
                {
                    string path = "/img/Produse/Tablets/" + uploadedFile.FileName;

                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    string way = "/img/Produse/Tablets/";

                    Tablets obj = new Tablets
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
                        materialul_carcasei = produs.materialul_carcasei,
                        dimensiuni = produs.dimensiuni,
                        capacitatea_bateriei = produs.capacitatea_bateriei,
                        greutate = produs.greutate,
                        garanție = produs.garanție,
                        culoare = produs.culoare
                    };
                    Tablets ob2 = db.tablets.Where(s => s.Id == produs.Id).FirstOrDefault();
                    db.tablets.Remove(ob2);
                    db.tablets.Add(obj);
                    db.SaveChanges();
                }
             return RedirectToAction("Index");
        }
         
        [HttpGet]
        public IActionResult Modifica(int? id)
        {
            if (id == null) return RedirectToAction("Index");
             ViewBag.ProdusId = id;
            Tablets obj = new Tablets();
            obj = db.tablets.FirstOrDefault(u => u.Id == id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewModel obj = new ViewModel();
            obj.viewTablets = db.tablets.ToList();
            Tablets A = new Tablets();
            A = obj.viewTablets.FirstOrDefault(x => x.Id == id);
            db.tablets.Remove(A);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)// Detaliile la un anumit produs
        {
            ViewModel obj = new ViewModel();
            obj.viewTablets = db.tablets.ToList();

            Tablets v = new Tablets();
            v = obj.viewTablets.FirstOrDefault(x => x.Id == id);
            return View(v);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
