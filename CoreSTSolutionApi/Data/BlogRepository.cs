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

        public async Task<Blog[]> GetAllBlogsAsync(bool includeCategory = false)
        {
            _logger.LogInformation($"Getting all Blogs.");

            IQueryable<Blog> query = _appDbContext.Blogs
                .Include(c => c.Category);

            query = query.OrderByDescending(b => b.Name);
            return await query.ToArrayAsync();
        }

        public async Task<Blog> GetBlogAsync(int blogId, bool includeCategory = false)
        {
            _logger.LogInformation($"Getting a Blog for {blogId}");

            IQueryable<Blog> query = _appDbContext.Blogs
                .Include(c => c.Category);

            query = query.Where(n => n.BlogId == blogId);
            return await query.FirstOrDefaultAsync();
        }
    }
}