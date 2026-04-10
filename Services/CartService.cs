using FullStack2._0.Models;
using FullStack2._0.Services.Interfaces;

namespace FullStack2._0.Services
{
    public class CartService : ICartService
    {
        private readonly List<OrderItem> _items = new();

        public List<OrderItem> GetItems() => _items;

        public void AddToCart(Product product)
        {
            if (_items.Any(i => i.ProductId == product.Id))
            {
                return;
            }

            _items.Add(new OrderItem
            {
                ProductId = product.Id,
                Product = product,
                PriceAtPurchase = product.Price
            });
        }

        public void RemoveFromCart(Product product)
        {
            OrderItem? item = _items.FirstOrDefault(i => i.ProductId == product.Id);

            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void ClearCart()
        {
            _items.Clear();
        }

        public decimal GetTotalPrice()
        {
            return _items.Sum(i => i.PriceAtPurchase);
        }
    }
}
