using Test_Backend.Repositories.Interfaces;
using Test_Backend.Repository;

namespace Test_Backend.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;

        public UnitOfWork(DBContext context)
        {
            _context = context;
        }

        public IProductRepository Products =>
            _productRepository ??= new ProductRepository(_context);

        public IOrderRepository Orders =>
            _orderRepository ??= new OrderRepository(_context);

        public IOrderItemRepository OrderItems =>
            _orderItemRepository ??= new OrderItemRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
