namespace Test_Backend.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        Task<int> SaveChangesAsync();
    }
}
