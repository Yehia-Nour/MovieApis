namespace MoviesApi.Services
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> CreateAsync(GenreDto dto);
        Task<Genre> UpdateAsync(int id, GenreDto dto);
        Task<Genre> DeleteAsync(int id);
        Task<bool> IsvalidGenre(int id);
    }
}
