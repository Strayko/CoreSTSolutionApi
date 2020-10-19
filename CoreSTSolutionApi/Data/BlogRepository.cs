using System;
using System.Linq;
using System.Threading.Tasks;
using CoreSTSolutionApi.Data.Entities;
using CoreSTSolutionApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreSTSolutionApi.Data
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<BlogRepository> _logger;

        public BlogRepository(AppDbContext appDbContext, ILogger<BlogRepository> logger) : base(appDbContext, logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Blog[]> GetAllBlogsAsync(bool includeTags = false)
        {
            _logger.LogInformation($"Getting all Blogs.");

            IQueryable<Blog> query = _appDbContext.Blogs
                .Include(c => c.Category);

            if (includeTags)
            {
                query = query
                    .Include(t => t.Tags);
            }

            query = query.OrderByDescending(b => b.Name);
            return await query.ToArrayAsync();
        }

        public async Task<Blog> GetBlogAsync(int blogId, bool includeTag = false)
        {
            _logger.LogInformation($"Getting a Blog for {blogId}");

            IQueryable<Blog> query = _appDbContext.Blogs
                .Include(c => c.Category);

            query = query.Where(n => n.BlogId == blogId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Blog[]> GetAllBlogsByName(string name)
        {
            _logger.LogInformation($"Getting all Blogs");

            IQueryable<Blog> query = _appDbContext.Blogs
                .Include(c => c.Category);

            query = query.OrderByDescending(b => b.Name)
                .Where(b => b.Name.Contains(name));

            return await query.ToArrayAsync();
        }

        public async Task<Blog> IsUnique(string name)
        {
            _logger.LogInformation($"Checks if there is an {name} in the database");
            
            IQueryable<Blog> query = _appDbContext.Blogs
                .Where(b => b.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Blog> SetModified(Blog model)
        {
            _appDbContext.SetModified(model);

            IQueryable<Blog> query = _appDbContext.Blogs
                .Where(b => b.BlogId == model.BlogId);

            return await query.FirstOrDefaultAsync();
        }
    }
}