using System.Threading.Tasks;
using CoreSTSolutionApi.Data.Entities;

namespace CoreSTSolutionApi.Data
{
    public interface IBlogRepository
    {
        Task<Blog[]> GetAllBlogsAsync(bool includeCategory = false);
        Task<Blog> GetBlogAsync(int blogId, bool includeCategory = false);
    }
}