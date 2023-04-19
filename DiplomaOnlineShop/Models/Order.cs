using Magazin.Models;
using System.Collections.Generic;

namespace DiplomaOnlineShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Oraș { get; set; }
        public string Strada { get; set; }
        public string Numar_de_telefon { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
