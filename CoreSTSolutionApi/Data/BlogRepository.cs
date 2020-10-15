using System.Linq;
using System.Threading.Tasks;
using CoreSTSolutionApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreSTSolutionApi.Data
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<BlogRepository> _logger;

        public BlogRepository(AppDbContext appDbContext, ILogger<BlogRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _appDbContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempting to save the changes in the context.");
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        public async Task<Blog[]> GetAllBlogsAsync(bool includeCategory = false)
        {
            _logger.LogInformation($"Getting all Blogs.");

            IQueryable<Blog> query = _appDbContext.Blogs
                .Include(c => c.Category);

            query = query.OrderByDescending(b => b.Name);
            return await query.ToArrayAsync();
        }

        public async Task<Blog> GetBlogAsync(string name, bool includeCategory = false)
        {
            _logger.LogInformation($"Getting a Blog for {name}");

            IQueryable<Blog> query = _appDbContext.Blogs
                .Include(c => c.Category);

            query = query.Where(n => n.Name == name);

            return await query.FirstOrDefaultAsync();
        }
    }
}