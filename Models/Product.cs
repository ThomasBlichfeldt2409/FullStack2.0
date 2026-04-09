using FullStack2._0.Enums;

namespace FullStack2._0.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public ProductStatus Status { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; } = null!;
        public List<ProductImage> Images { get; set; } = null!;
    }
}
