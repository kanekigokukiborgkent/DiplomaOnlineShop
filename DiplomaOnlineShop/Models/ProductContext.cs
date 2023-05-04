using Magazin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaOnlineShop.Models
{
    public class ProductContext :DbContext
    {
        public DbSet<Products> products{ get; set; }
        public DbSet<AdminUser> AdminUsers{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderProducts> orderProducts{ get; set; }
        public DbSet<ProductOrder> ProductOrders{ get; set; }
         public ProductContext(DbContextOptions<ProductContext> options)
             : base(options)
         {
            Database.EnsureCreated();

        }

    }
}
