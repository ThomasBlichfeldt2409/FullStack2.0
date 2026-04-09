namespace FullStack2._0.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
