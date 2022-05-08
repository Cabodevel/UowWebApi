using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UowWebApi.Data;
using UowWebApi.IRepositories;

namespace UowWebApi.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext context;
        internal DbSet<T> dbSet;
        public readonly ILogger _logger;

        public GenericRepository(
            ApplicationDbContext context,
            ILogger logger)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<List<T>> All()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public abstract Task<bool> Delete(Guid id);

        public abstract Task<bool> Upsert(T entity);
    }
}
