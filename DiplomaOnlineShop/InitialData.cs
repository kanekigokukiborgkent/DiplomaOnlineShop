using DiplomaOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace DiplomaOnlineShop
{
    static public class InitialData
    {
        public static List<Telephones> telephones = new List<Telephones>
        {
            new Telephones {producător="Maxconi",model="Maxcom mk281", pret = 3000, diagonala_ecranului = 2.8 , memorie_incorporată= 4,  RAM = 512 ,  camera_principală = 2,  camera_frontala = 0.3 , capacitatea_bateriei = 1800,  garanție = 6, culoare = "Negru", Img ="phone1.PNG", Path="/img/Produse/Telephons/"}
        };

        public static List<User> users = new List<User>
        {
            new User {login="nicu", password="12345"}
          };

      /*  public static Dictionary<string, Telephones> DicTelephones
        {
            get
            {
                Dictionary<string, Telephones> dic = new Dictionary<string, Telephones>();
                foreach (var el in telephones)
                    dic.Add(el.producător, el);

                return dic;
            }
        }*/

        public static List<Tablets> tablets = new List<Tablets>
        {
            new Tablets {producător = "Xiaomi", model="Lenovo Smart Tab M8", pret = 3000, diagonala_ecranului = 11, rezolutia_ecranului = "2560x1600", memorie_incorporată = 128, RAM = 6, camera_din_spate = 13, camera_frontala = 8, capacitatea_bateriei = 8720, garanție = 24, materialul_carcasei = "aluminiu", dimensiuni = "254,6x166,2x6,8", greutate = 511, culoare = "Gri", Img ="tablet1.PNG", Path="/img/Produse/Tablets/" }
        };
        public static void Initialize(ProductContext db)
        {
            if (!db.telephones.Any())
                db.telephones.AddRange(telephones);
            if (!db.tablets.Any())
                db.tablets.AddRange(tablets);
            if (!db.users.Any())
                db.users.AddRange(users);
            db.SaveChanges();
        }
    }
}
