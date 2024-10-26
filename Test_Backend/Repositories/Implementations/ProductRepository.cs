using Microsoft.EntityFrameworkCore;
using Test_Backend.Models.Entities;
using Test_Backend.Repositories.Interfaces;
using Test_Backend.Repository;

namespace Test_Backend.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DBContext context) : base(context) { }

        public async Task<string> GenerateProductCodeAsync()
        {
            var lastProduct = await _dbSet
                .OrderByDescending(p => p.ProductCode)
                .FirstOrDefaultAsync();

            if (lastProduct == null)
                return "PR0001";

            var currentNumber = int.Parse(lastProduct.ProductCode.Substring(2));
            return $"PR{(currentNumber + 1).ToString("D4")}";
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            return await _dbSet
                .Where(p => p.Name.Contains(searchTerm) || p.ProductCode.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<bool> UpdateStatusAsync(string productCode, bool isActive)
        {
            var product = await _dbSet.FindAsync(productCode);
            if (product == null)
                return false;

            product.IsActive = isActive;
            product.UpdatedAt = DateTime.UtcNow;
            return true;
        }
    }
}
