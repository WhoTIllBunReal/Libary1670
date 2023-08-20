namespace Libary1670.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; } // Foreign key to Category
    }
}
