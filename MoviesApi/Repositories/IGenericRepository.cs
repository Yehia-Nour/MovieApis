using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
    }
}
