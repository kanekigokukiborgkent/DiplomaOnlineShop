namespace DiplomaOnlineShop.Models
{
    public class ProdOrder   //FullOrder
    {
        public int Id { get; set; }
        public string Order { get; set; }
        public string Produs { get; set; }
        public string Oras { get; set; }
        public string Strada { get; set; }
        public string Numar_Telefon { get; set; }
        public double Pret { get; set; }
        public string Path { get; set; }
    }
}