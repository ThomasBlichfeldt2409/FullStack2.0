using FullStack2._0.Models;

namespace FullStack2._0.Services.Interfaces
{
    public interface ICartService
    {
        List<OrderItem> GetItems();
        void AddToCart(Product product);
        void RemoveFromCart(Product product);
        void ClearCart();
        decimal GetTotalPrice();
    }
}
