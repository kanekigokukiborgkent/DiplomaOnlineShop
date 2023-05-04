namespace DiplomaOnlineShop.Models
{
    public class OrderProducts
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}
