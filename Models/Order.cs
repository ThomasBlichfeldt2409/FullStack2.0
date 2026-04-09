using FullStack2._0.Enums;
using FullStack2._0.Data;

namespace FullStack2._0.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }

        public ApplicationUser User { get; set; } = null!;
        public List<OrderItem> Items { get; set; } = null!;
    }
}
