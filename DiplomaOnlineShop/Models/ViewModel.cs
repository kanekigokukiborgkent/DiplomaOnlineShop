using System.Collections.Generic;
namespace DiplomaOnlineShop.Models
{
    public class ViewModel
    {
        public List<Products> viewProducts { get; set; }
        public List<AdminUser> viewAdminUsers{ get; set; }
        public List <Order> orders{ get; set; }
        public List <ProdNamesOrders> prodNamesOrders{ get; set; }
        public List <ProdOrder> prodOrders{ get; set; }
    }
}
