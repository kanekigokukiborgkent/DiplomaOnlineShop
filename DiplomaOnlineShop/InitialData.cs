﻿using DiplomaOnlineShop.Models;
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
            new Telephones {producător="Maxconi",model="Maxcom mk281", pret = 3000, diagonala_ecranului = 2.8 , memorie_incorporată= 4,  RAM = 512  ,  camera_principală = 4,  camera_frontala = 1.3 , capacitatea_bateriei = 1800,  garanție = 6, culoare = "Negru", Img ="phone1.PNG", Path="/img/Produse/Telephons/"},
            new Telephones {producător="Apple",model="Iphone 8",       pret = 2990, diagonala_ecranului = 2.6 , memorie_incorporată= 8,  RAM = 1024 ,  camera_principală = 3,  camera_frontala = 2.3 , capacitatea_bateriei = 1890,  garanție = 12, culoare = "Albastru", Img ="phone2.PNG", Path="/img/Produse/Telephons/"},
            new Telephones {producător="Samsung",model="Galaxy 43 A ", pret = 2980, diagonala_ecranului = 2.4 , memorie_incorporată= 6,  RAM = 2048 ,  camera_principală = 2,  camera_frontala = 3.3 , capacitatea_bateriei = 1980,  garanție = 24, culoare = "Alb", Img ="phone3.PNG", Path="/img/Produse/Telephons/"},
            new Telephones {producător="Xiaomi",model="Redmi 4",       pret = 2893, diagonala_ecranului = 3.8 , memorie_incorporată= 4,  RAM = 1054 ,  camera_principală = 1,  camera_frontala = 4.3 , capacitatea_bateriei = 1400,  garanție = 18, culoare = "Sur", Img ="phone4.PNG", Path="/img/Produse/Telephons/"},
            new Telephones {producător="Poco",model="Phone XR",        pret = 3422, diagonala_ecranului = 4.8 , memorie_incorporată= 2,  RAM = 3022 ,  camera_principală = 3,  camera_frontala = 5.3 , capacitatea_bateriei = 2800,  garanție = 48, culoare = "Negru", Img ="phone5.PNG", Path="/img/Produse/Telephons/"},
            new Telephones {producător="Dodge",model="Viper Monster",  pret = 3900, diagonala_ecranului = 2.0 , memorie_incorporată= 3,  RAM = 1234 ,  camera_principală = 5,  camera_frontala = 6.3 , capacitatea_bateriei = 3800,  garanție = 36, culoare = "Gri", Img ="phone6.PNG", Path="/img/Produse/Telephons/"}
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
            new Tablets {producător = "Xiaomi", model="Smart Tab M8",        pret = 3000, diagonala_ecranului = 12, rezolutia_ecranului = "2560x1300", memorie_incorporată = 128, RAM = 6, camera_din_spate = 13, camera_frontala = 8, capacitatea_bateriei = 8720, garanție = 24, materialul_carcasei = "aluminiu", dimensiuni = "254,6x166,2x1,4", greutate = 511, culoare = "Gri", Img ="tablet1.PNG", Path="/img/Produse/Tablets/" },
            new Tablets {producător = "Poco", model=" Tablet 54 C",          pret = 3293, diagonala_ecranului = 13, rezolutia_ecranului = "2420x1600", memorie_incorporată = 64,  RAM = 3, camera_din_spate = 14, camera_frontala = 6, capacitatea_bateriei = 7322, garanție = 6 , materialul_carcasei = "aluminiu", dimensiuni = "153,5x654,2x9,4", greutate = 600, culoare = "Negru", Img ="tablet2.PNG", Path="/img/Produse/Tablets/" },
            new Tablets {producător = "Samsung", model="Galaxy A3",          pret = 2484, diagonala_ecranului = 14, rezolutia_ecranului = "2304x2344", memorie_incorporată = 165, RAM = 4, camera_din_spate = 12, camera_frontala = 7, capacitatea_bateriei = 6324, garanție = 12, materialul_carcasei = "aluminiu", dimensiuni = "544,1x645,4x8,3", greutate = 612, culoare = "Albastru", Img ="tablet3.PNG", Path="/img/Produse/Tablets/" },
            new Tablets {producător = "LG", model="Aparat GY 78",            pret = 3333, diagonala_ecranului = 11, rezolutia_ecranului = "2743x7367", memorie_incorporată = 134, RAM = 6, camera_din_spate = 15, camera_frontala = 9, capacitatea_bateriei = 7320, garanție = 6,  materialul_carcasei = "aluminiu", dimensiuni = "743,2x343,2x7,3", greutate = 432, culoare = "Argintiu", Img ="tablet4.PNG", Path="/img/Produse/Tablets/" },
            new Tablets {producător = "Apple", model="MacBook Pro ",         pret = 3055, diagonala_ecranului = 10, rezolutia_ecranului = "2735x1345", memorie_incorporată = 28,  RAM = 2, camera_din_spate = 16, camera_frontala = 2, capacitatea_bateriei = 2320, garanție = 48, materialul_carcasei = "aluminiu", dimensiuni = "346,3x466,4x6,2", greutate = 523, culoare = "Blue-Marin", Img ="tablet5.PNG", Path="/img/Produse/Tablets/" },
            new Tablets {producător = "Xiaomi", model="Flip Hy LY Ky Ny My", pret = 4392, diagonala_ecranului = 15, rezolutia_ecranului = "2724x1783", memorie_incorporată = 29,  RAM = 3, camera_din_spate = 11, camera_frontala = 1, capacitatea_bateriei = 6320, garanție = 36, materialul_carcasei = "aluminiu", dimensiuni = "487,2x821,1x5,3", greutate = 854, culoare = "Alb", Img ="tablet6.PNG", Path="/img/Produse/Tablets/" }
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
