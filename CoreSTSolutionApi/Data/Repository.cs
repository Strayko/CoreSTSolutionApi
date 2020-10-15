using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreSTSolutionApi.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext DbContext;
        private readonly ILogger<Repository<T>> _logger;
        internal DbSet<T> dbSet;

        public Repository(DbContext dbContext, ILogger<Repository<T>> logger)
        {
            DbContext = dbContext;
            _logger = logger;
            this.dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            dbSet.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempting to save the changes in the context.");
            return (await DbContext.SaveChangesAsync()) > 0;
        }
    }
}