using System.Linq;
using System.Threading.Tasks;
using CoreSTSolutionApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreSTSolutionApi.Data
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(AppDbContext appDbContext, ILogger<CategoryRepository> logger) : base(appDbContext, logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Category[]> GetAllCategoriesAsync(bool includeCategory = false)
        {
            _logger.LogInformation($"Getting all Categories.");

            IQueryable<Category> query = _appDbContext.Categories
                .Include(c => c.Blogs);

            query = query.OrderByDescending(b => b.CategoryName);
            return await query.ToArrayAsync();
        }

        public async Task<Category> GetCategoryAsync(string name, bool includeCategory = false)
        {
            _logger.LogInformation($"Getting a Category for {name}");

            IQueryable<Category> query = _appDbContext.Categories
                .Include(c => c.Blogs);

            query = query.Where(n => n.CategoryName == name);
            return await query.FirstOrDefaultAsync();
        }
    }
}