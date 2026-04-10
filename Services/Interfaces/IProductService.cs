using FullStack2._0.Models;

namespace FullStack2._0.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
