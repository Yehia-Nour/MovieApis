
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Services
{
    public class GenresService : IGenresService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenresService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _unitOfWork.Genres.GetAll()
                    .Select(g => new Genre { Id = g.Id, Name = g.Name })
                    .OrderBy(g => g.Name)
                    .ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);
            return genre;
        }
        public async Task<Genre> CreateAsync(GenreDto dto)
        {
            Genre genre = new Genre()
            {
                Name = dto.Name
            };
            await _unitOfWork.Genres.CreateAsync(genre);
            await _unitOfWork.CompleteAsync();
            return genre;
        }


        public async Task<Genre> UpdateAsync(int id, GenreDto dto)
        {
            var genre = await GetByIdAsync(id);
            if (genre == null)
                return genre;

            genre.Name = dto.Name;
            await _unitOfWork.CompleteAsync();
            return genre;
        }
        public async Task<Genre> DeleteAsync(int id)
        {
            var genre = await GetByIdAsync(id);
            await _unitOfWork.Genres.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return genre;
        }

        public async Task<bool> IsvalidGenre(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);
            if(genre == null)
                return false;
            return true;
        }

    }
}
