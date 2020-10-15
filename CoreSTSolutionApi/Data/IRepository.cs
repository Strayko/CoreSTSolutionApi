using System.Threading.Tasks;

namespace CoreSTSolutionApi.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
    }
}