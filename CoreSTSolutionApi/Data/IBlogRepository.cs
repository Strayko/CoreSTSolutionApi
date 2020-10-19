using System.Threading.Tasks;
using CoreSTSolutionApi.Data.Entities;

namespace CoreSTSolutionApi.Data
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<Blog[]> GetAllBlogsAsync(bool includeTags = false);
        Task<Blog> GetBlogAsync(int blogId, bool includeTag = false);
        Task<Blog[]> GetAllBlogsByName(string name);
        Task<Blog> IsUnique(string name);
    }
}