using DiplomaOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class ProductOrder
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Products { get; set; }
        public string Path { get; set; }
        public double Pret { get; set; }
    }
}
