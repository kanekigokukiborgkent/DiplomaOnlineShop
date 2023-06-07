using DiplomaOnlineShop.Models;
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
