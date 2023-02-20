using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaOnlineShop.Models
{
    public class ProductContext :DbContext
    {
        public DbSet<Telephones> telephones{ get; set; }
        public DbSet<Tablets> tablets{ get; set; }
        public DbSet<User> users{ get; set; }
         public ProductContext(DbContextOptions<ProductContext> options)
             : base(options)
         {
            Database.EnsureCreated();

        }

    }
}
