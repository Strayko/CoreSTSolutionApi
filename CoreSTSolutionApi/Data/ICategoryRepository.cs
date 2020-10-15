using System.Threading.Tasks;
using CoreSTSolutionApi.Data.Entities;

namespace CoreSTSolutionApi.Data
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category[]> GetAllCategoriesAsync(bool includeBlog = false);
        Task<Category> GetCategoryAsync(string name, bool includeBlog = false);
    }
}