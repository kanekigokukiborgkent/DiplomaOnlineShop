using DiplomaOnlineShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiplomaOnlineShop
{
    static public class InitialData
    {
        public static List<Products> products = new List<Products>
        {
            new Products {producător = "Xiaomi", model="Smart Tab M8",        pret = 3000, diagonala_ecranului = 12, rezolutia_ecranului = "2560x1300", memorie_incorporată = 128, RAM = 6, camera_din_spate = 13, camera_frontala = 8, capacitatea_bateriei = 8720, garanție = 24, culoare = "Gri",        Img ="tablet1.jpg", Path="/img/Produse/Tablets/", category = "tablet" },
            new Products {producător = "Poco", model=" Tablet 54 C",          pret = 3293, diagonala_ecranului = 13, rezolutia_ecranului = "2420x1600", memorie_incorporată = 64,  RAM = 3, camera_din_spate = 14, camera_frontala = 6, capacitatea_bateriei = 7322, garanție = 6 , culoare = "Negru",      Img ="tablet2.png", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "Samsung", model="Galaxy A3",          pret = 2484, diagonala_ecranului = 14, rezolutia_ecranului = "2304x2344", memorie_incorporată = 165, RAM = 4, camera_din_spate = 12, camera_frontala = 7, capacitatea_bateriei = 6324, garanție = 12, culoare = "Albastru",   Img ="tablet3.jpg", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "LG", model="Des 7D",                  pret = 3333, diagonala_ecranului = 11, rezolutia_ecranului = "2743x7367", memorie_incorporată = 134, RAM = 6, camera_din_spate = 15, camera_frontala = 9, capacitatea_bateriei = 7320, garanție = 6,  culoare = "Argintiu",   Img ="tablet4.jpg", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "LG", model="Des 7D",                  pret = 3333, diagonala_ecranului = 11, rezolutia_ecranului = "2743x7367", memorie_incorporată = 134, RAM = 6, camera_din_spate = 15, camera_frontala = 9, capacitatea_bateriei = 7320, garanție = 6,  culoare = "Argintiu",   Img ="tablet5.jpg", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "LG", model="Des 7D",                  pret = 3333, diagonala_ecranului = 11, rezolutia_ecranului = "2743x7367", memorie_incorporată = 134, RAM = 6, camera_din_spate = 15, camera_frontala = 9, capacitatea_bateriei = 7320, garanție = 6,  culoare = "Argintiu",   Img ="tablet6.jpg", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "LG", model="Des 7D",                  pret = 3333, diagonala_ecranului = 11, rezolutia_ecranului = "2743x7367", memorie_incorporată = 134, RAM = 6, camera_din_spate = 15, camera_frontala = 9, capacitatea_bateriei = 7320, garanție = 6,  culoare = "Argintiu",   Img ="tablet7.jpg", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "LG", model="Des 7D",                  pret = 3333, diagonala_ecranului = 11, rezolutia_ecranului = "2743x7367", memorie_incorporată = 134, RAM = 6, camera_din_spate = 15, camera_frontala = 9, capacitatea_bateriei = 7320, garanție = 6,  culoare = "Argintiu",   Img ="tablet8.jpg", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "LG", model="Des 7D",                  pret = 3333, diagonala_ecranului = 11, rezolutia_ecranului = "2743x7367", memorie_incorporată = 134, RAM = 6, camera_din_spate = 15, camera_frontala = 9, capacitatea_bateriei = 7320, garanție = 6,  culoare = "Argintiu",   Img ="tablet9.jpg", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "LG", model="Des 7D",                  pret = 3333, diagonala_ecranului = 11, rezolutia_ecranului = "2743x7367", memorie_incorporată = 134, RAM = 6, camera_din_spate = 15, camera_frontala = 9, capacitatea_bateriei = 7320, garanție = 6,  culoare = "Argintiu",   Img ="tablet10.jpg", Path="/img/Produse/Tablets/" , category = "tablet"},
            new Products {producător = "Apple", model="MacBook Pro ",         pret = 3055, diagonala_ecranului = 10, rezolutia_ecranului = "2735x1345", memorie_incorporată = 28,  RAM = 2, camera_din_spate = 16, camera_frontala = 2, capacitatea_bateriei = 2320, garanție = 48, culoare = "Blue-Marin", Img ="phone1.jpg", Path="/img/Produse/Telephons/" , category = "phone"},
            new Products {producător = "Xiaomi", model="Redmi Note 4 S",      pret = 4392, diagonala_ecranului = 15, rezolutia_ecranului = "2724x1783", memorie_incorporată = 29,  RAM = 3, camera_din_spate = 11, camera_frontala = 4, capacitatea_bateriei = 2530, garanție = 38, culoare = "Alb",        Img ="phone2.png", Path="/img/Produse/Telephons/" , category = "phone"},
            new Products {producător = "Apple", model="IPhone 4 Plus",        pret = 3302, diagonala_ecranului = 17, rezolutia_ecranului = "2824x1884", memorie_incorporată = 34,  RAM = 5, camera_din_spate = 13, camera_frontala = 3, capacitatea_bateriei = 6353, garanție = 36, culoare = "Alb",        Img ="phone3.jpg", Path="/img/Produse/Telephons/" , category = "phone"},
            new Products {producător = "Motorola", model="Notri 7J",          pret = 2741, diagonala_ecranului = 13, rezolutia_ecranului = "2273x1365", memorie_incorporată = 23,  RAM = 4, camera_din_spate = 12, camera_frontala = 1, capacitatea_bateriei = 6321, garanție = 33, culoare = "Alb",        Img ="phone4.jpg", Path="/img/Produse/Telephons/" , category = "phone"},
            new Products {producător = "Motorola", model="Notri 7J",          pret = 2741, diagonala_ecranului = 13, rezolutia_ecranului = "2273x1365", memorie_incorporată = 23,  RAM = 4, camera_din_spate = 12, camera_frontala = 1, capacitatea_bateriei = 6321, garanție = 33, culoare = "Alb",        Img ="phone5.jpg", Path="/img/Produse/Telephons/" , category = "phone"},
            new Products {producător = "Motorola", model="Notri 7J",          pret = 2741, diagonala_ecranului = 13, rezolutia_ecranului = "2273x1365", memorie_incorporată = 23,  RAM = 4, camera_din_spate = 12, camera_frontala = 1, capacitatea_bateriei = 6321, garanție = 33, culoare = "Alb",        Img ="phone6.jpg", Path="/img/Produse/Telephons/" , category = "phone"},
            new Products {producător = "Motorola", model="Notri 7J",          pret = 2741, diagonala_ecranului = 13, rezolutia_ecranului = "2273x1365", memorie_incorporată = 23,  RAM = 4, camera_din_spate = 12, camera_frontala = 1, capacitatea_bateriei = 6321, garanție = 33, culoare = "Alb",        Img ="phone7.jpg", Path="/img/Produse/Telephons/" , category = "phone"},
            new Products {producător = "Motorola", model="Notri 7J",          pret = 2741, diagonala_ecranului = 13, rezolutia_ecranului = "2273x1365", memorie_incorporată = 23,  RAM = 4, camera_din_spate = 12, camera_frontala = 1, capacitatea_bateriei = 6321, garanție = 33, culoare = "Alb",        Img ="phone8.jpg", Path="/img/Produse/Telephons/" , category = "phone"},
   };
        public static List<AdminUser> AdminUsers = new List<AdminUser>
        {
            new AdminUser {login="nicu", password="12345"}
          };
        public static void Initialize(ProductContext db)
        {
            if (!db.products.Any())
                db.products.AddRange(products);
            if (!db.AdminUsers.Any())
                db.AdminUsers.AddRange(AdminUsers);
            db.SaveChanges();
        }
    }
}
