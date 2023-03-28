using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DiplomaOnlineShop.Models;
using DiplomaOnlineShop;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using System.Security.Claims;
using DiplomaOnlineShop.Controllers;

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
        // Produsele pentru manager
        [HttpGet]
        [Authorize]
        public IActionResult Meniu_manager()
        {
            ViewModel obj = new ViewModel();
            obj.viewProducts = db.products.ToList();
             
            return View(obj);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
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
            return RedirectToAction("Index");
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

        /*  [HttpPost]// Adaugarea Produs in BD
          public async Task<IActionResult> Add(IFormFile uploadedFile, Produs produs)
          {
              if (securitProdus(produs) == true)
              {
                  if (uploadedFile != null)
                  {

                      string path = "/img/Produse/" + uploadedFile.FileName;

                      using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                      {
                          await uploadedFile.CopyToAsync(fileStream);
                      }
                      string way = "/img/Produse/";
                      Produs file = new Produs { Img = uploadedFile.FileName, Path = way };
                      Produs obj = new Produs
                      {
                          Name = produs.Name,
                          Company = produs.Company,
                          Desc = produs.Desc,
                          Img = file.Img,
                          Path = file.Path,
                          Price = produs.Price,
                          Favourite = produs.Favourite,
                          categoryID = produs.categoryID,
                          category = produs.category

                      };
                      db.Produse.Add(obj);
                      db.SaveChanges();
                  }


                  logger.LogInformation("Admin a adaugat un nou produs");
                  return RedirectToAction("Meniu_manager");
              }
              return View();
          }

          public bool securitProdus(Produs produs)
          {
              NotNull obj = new NotNull();
              string k = obj.securitProdus(produs);
              if (k.Contains("1"))
                  ViewBag.ErrName = obj.errorMessage;
              if (k.Contains("2"))
                  ViewBag.ErrCompany = obj.errorMessage;
              if (k.Contains("3"))
                  ViewBag.ErrFavourite = obj.errorMessage;
              if (k.Contains("4"))
                  ViewBag.ErrCategory = obj.errorMessage;
              if (k.Contains("5"))
                  ViewBag.ErrPrice = obj.errorMessage;
              if (k.Contains("6"))
                  ViewBag.ErrDesc = obj.errorMessage;


              if (k == "")
                  return true;
              return false;
          }

          [HttpGet]
          public IActionResult Logs()
          {

              ViewModel obj = new ViewModel();
              obj.viewLog = db.Logs.ToList();
              return View(obj.viewLog);
          }
          public FileResult DownloadFile(string fileName)
          {
              //Build the File Path.
              string path = fileName;

              //Read the File data into Byte Array.
              byte[] bytes = System.IO.File.ReadAllBytes(path);

              //Send the File to Download.
              return File(bytes, "application/octet-stream", fileName);
          }


          [HttpGet]
          public IActionResult Show(int id)
          {
              ViewModel obj = new ViewModel();
              obj.viewProdus = db.Produse.ToList();
              Produs v = new Produs();
              v = obj.viewProdus.FirstOrDefault(x => x.Id == id);
              logger.LogInformation($"Admin acceseaza desfasurat produsul cu id {id}");
              return View(v);
          }

          public IActionResult Orders()
          {

              logger.LogInformation($"Admin incearca sa vada orderele");

              IEnumerable<FullOrder> obj = new List<FullOrder>();
              obj = join();


              return View(obj);
          }

          [HttpGet]
          public IActionResult Change(int? id)
          {
              if (id == null) return RedirectToAction("Index");
              logger.LogInformation($"Admin incearca sa modifice produsul cu id: {id}");
              ViewBag.ProdusId = id;
              Produs obj = new Produs();
              obj = db.Produse.FirstOrDefault(u => u.Id == id);


              return View(obj);
          }


          [HttpPost]// Modificarea produs
          public async Task<IActionResult> Change(IFormFile uploadedFile, Produs produs, int id)
          {
              if (securitProdus(produs))
              {
                  if (uploadedFile != null)
                  {

                      string path = "/img/Produse/" + uploadedFile.FileName;

                      using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                      {
                          await uploadedFile.CopyToAsync(fileStream);
                      }
                      string way = "/img/Produse/";

                      Produs obj = new Produs
                      {
                          Id = id,
                          Name = produs.Name,
                          Company = produs.Company,
                          Desc = produs.Desc,
                          Img = uploadedFile.FileName,
                          Path = way,
                          Price = produs.Price,
                          Favourite = produs.Favourite,
                          categoryID = produs.categoryID,
                          category = produs.category

                      };
                      Produs ob2 = db.Produse.Where(s => s.Id == produs.Id).FirstOrDefault();
                      db.Produse.Remove(ob2);
                      db.Produse.Add(obj);


                      db.SaveChanges();
                  }

                  logger.LogInformation($"Admin a modificat produsul cu id {{id}}");
                  return RedirectToAction("Meniu_manager");

              }
              Produs obj2 = new Produs();
              obj2 = db.Produse.FirstOrDefault(u => u.Id == id);
              return View(obj2);
          }

          [HttpGet]
          public IActionResult Add()
          {
              logger.LogInformation("Admin incearca sa adauge produs");
              return View();
          }



          // Stergerea produsului
          [HttpGet]
          public IActionResult Delete(int id)
          {
              ViewModel obj = new ViewModel();
              obj.viewProdus = db.Produse.ToList();
              Produs A = new Produs();
              A = obj.viewProdus.FirstOrDefault(x => x.Id == id);
              db.Produse.Remove(A);

              db.SaveChanges();
              logger.LogInformation($"Admin a sters produs cu Id {id}");
              return RedirectToAction("Meniu_manager");
          }

          public List<FullOrder> join()
          {
              List<OrderWithProdName> first = new List<OrderWithProdName>();
              first = db.OrdersProdus.Join(db.Produse,
                  u => u.ProdusId,
                  p => p.Id,
                  (u, p) => new OrderWithProdName
                  { Id = u.Id, OrderId = u.OrderId, Order = u.Order, Produs = p.Name }

                  ).ToList();
              // db.SaveChanges();
              List<FullOrder> last = new List<FullOrder>();
              last = first.Join(db.Orders,
                  p => p.OrderId,
                  u => u.OrderId,
                  (p, u) => new FullOrder
                  {
                      Id = p.Id,
                      Produs = p.Produs,
                      Order = u.User

                  }
                  ).ToList();

              return last;

          }

          public async Task<IActionResult> SendMessage()
          {
              string adress = "d.sterbet31@gmail.com";

              System.Net.WebClient client = new WebClient();
              String htmlCode = client.DownloadString(@"C:\Users\AC Tech\Source\Repos\Magazin\Magazin\wwwroot\body.html");


              try
              {
                  EmailService emailService = new EmailService();
                  await emailService.SendEmailAsync(adress, "Test", htmlCode);
                  logger.LogInformation($"Mesajul s-a transmis la adresa: {adress}");
              }
              catch
              {
                  logger.LogInformation($"Mesajul nu s-a putut transmite la adresa {adress}");

              }
              return RedirectToAction("Meniu_manager");
          }

          public IActionResult Export()
          {
              DataTable dt = new DataTable("Grid");
              dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Pret"),
                                          new DataColumn("Denumire"),
                                          new DataColumn("Companie"),
                                          new DataColumn("Categorie") });

              var customers = db.Produse.Join(db.Categories,

                  u => u.categoryID,
                  p => p.Id,
                  (u, p) => new
                  {
                      Name = u.Name,
                      Price = u.Price,
                      Company = u.Company,
                      Category = p.Name
                  }
               ).ToList();

              foreach (var customer in customers)
              {
                  dt.Rows.Add(customer.Price, customer.Name, customer.Company, customer.Category);
              }

              using (XLWorkbook wb = new XLWorkbook())
              {
                  wb.Worksheets.Add(dt);
                  using (MemoryStream stream = new MemoryStream())
                  {
                      wb.SaveAs(stream);
                      return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                  }
              }


          }*/
    }
}