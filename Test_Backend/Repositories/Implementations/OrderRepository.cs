using Microsoft.EntityFrameworkCore;
using Test_Backend.Models.Entities;
using Test_Backend.Repositories.Interfaces;
using Test_Backend.Repository;

namespace Test_Backend.Repositories.Implementations
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DBContext context) : base(context) { }

        public async Task<string> GenerateOrderCodeAsync()
        {
            var today = DateTime.Now;
            var prefix = $"OD{today:ddMMyy}";

            var lastOrder = await _dbSet
                .Where(o => o.OrderCode.StartsWith(prefix))
                .OrderByDescending(o => o.OrderCode)
                .FirstOrDefaultAsync();

            if (lastOrder == null)
                return $"{prefix}001";

            var currentNumber = int.Parse(lastOrder.OrderCode.Substring(8));
            return $"{prefix}{(currentNumber + 1).ToString("D3")}";
        }

        public async Task<Order> GetOrderWithDetailsAsync(string orderCode)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode);
        }

        public async Task<IEnumerable<Order>> GetOrdersWithDetailsAsync()
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }
    }
}
