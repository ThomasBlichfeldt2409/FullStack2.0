namespace FullStack2._0.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;

        public decimal PriceAtPurchase { get; set; }
    }
}
