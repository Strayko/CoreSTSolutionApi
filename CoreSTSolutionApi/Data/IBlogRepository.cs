using System.Threading.Tasks;
using CoreSTSolutionApi.Data.Entities;

namespace CoreSTSolutionApi.Data
{
    public interface IBlogRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Blog[]> GetAllBlogsAsync(bool includeCategory = false);
        Task<Blog> GetBlogAsync(string name, bool includeCategory = false);
    }
}