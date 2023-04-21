using DiplomaOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaOnlineShop.Models
{
    public class ProdNamesOrders
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Produs { get; set; }
    }
}
