using Test_Backend.Models.Entities;

namespace Test_Backend.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<string> GenerateProductCodeAsync();
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
        Task<bool> UpdateStatusAsync(string productCode, bool isActive);
    }
}
