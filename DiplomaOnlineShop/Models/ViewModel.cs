using DiplomaOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaOnlineShop.Models
{
    public class ViewModel
    {
        public List<Telephones> viewTelephones { get; set; }
        public List<Products> viewTablets { get; set; }


    }
}
