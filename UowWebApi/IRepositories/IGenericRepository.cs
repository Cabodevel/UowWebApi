using System.Linq.Expressions;

namespace UowWebApi.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> All();
        Task<T?> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);
        Task<List<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
