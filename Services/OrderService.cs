using FullStack2._0.Models;
using FullStack2._0.Data;
using FullStack2._0.Enums;
using FullStack2._0.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStack2._0.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Include(o => o.User)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task CreateAsync(string userId, List<OrderItem> items)
        {
            decimal total = items.Sum(i => i.PriceAtPurchase);

            Order order = new Order
            {
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Requested,
                TotalPrice = total,
                Items = items
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int orderId, OrderStatus status)
        {
            Order? existing = await _context.Orders.FindAsync(orderId);

            if (existing == null)
            {
                return;
            }

            existing.Status = status;
            
            await _context.SaveChangesAsync();
        }
    }
}
