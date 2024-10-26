using Test_Backend.Models.Entities;

namespace Test_Backend.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<string> GenerateOrderCodeAsync();
        Task<Order> GetOrderWithDetailsAsync(string orderCode);
        Task<IEnumerable<Order>> GetOrdersWithDetailsAsync();
    }
}
