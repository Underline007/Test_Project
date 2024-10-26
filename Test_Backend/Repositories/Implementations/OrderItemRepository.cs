using Test_Backend.Models.Entities;
using Test_Backend.Repositories.Interfaces;
using Test_Backend.Repository;

namespace Test_Backend.Repositories.Implementations
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DBContext context) : base(context) { }
    }
}
