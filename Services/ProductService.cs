using FullStack2._0.Data;
using FullStack2._0.Models;
using FullStack2._0.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStack2._0.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            Product? existing = await _context.Products.FindAsync(product.Id);

            if (existing == null)
            {
                return;
            }

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Status = product.Status;
            existing.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
        }
    }
}
