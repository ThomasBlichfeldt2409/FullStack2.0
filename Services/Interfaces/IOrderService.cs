using FullStack2._0.Models;
using FullStack2._0.Enums;

namespace FullStack2._0.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task CreateAsync(string userId, List<OrderItem> items);
        Task UpdateStatusAsync(int OrderId, OrderStatus staus);
    }
}
