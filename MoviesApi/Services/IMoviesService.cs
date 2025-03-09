namespace MoviesApi.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDetailsDto>> GetAllAsync(int genreId = 0);
        Task<MovieDetailsDto> GetByIdAsync(int id);
        Task<MovieDetailsDto> CreateAsync(MovieDto dto);
        Task<MovieDetailsDto> UpdateAsync(int id, MovieDto dto);
        Task<MovieDetailsDto> DeleteAsync(int id);
    }
}
