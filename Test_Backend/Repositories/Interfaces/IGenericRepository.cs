using System.Linq.Expressions;

namespace Test_Backend.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> filter = null);
    }

}
