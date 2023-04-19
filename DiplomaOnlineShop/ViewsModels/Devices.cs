using DiplomaOnlineShop.Models;
using DiplomaOnlineShop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaOnlineShop.ViewModels
{
    public class ViewModels
    {
        public List<Products> ViewProducts { get; set; }
        public List<Order> ViewOrders{ get; set; }

    }
}
