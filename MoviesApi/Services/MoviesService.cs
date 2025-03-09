
namespace MoviesApi.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MoviesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieDetailsDto>> GetAllAsync(int genreId = 0)
        {
            var movies = await _unitOfWork.Movies.GetAll()
                .Where(m => m.GenreId == genreId || genreId == 0)
                .OrderByDescending(m => m.Rate)
                .Include(m => m.Genre)
                .ToListAsync();

            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(movies);
            return data;
        }

        public async Task<MovieDetailsDto> GetByIdAsync(int id)
        {
            var movie = await _unitOfWork.Movies.GetByIdAsync(id);

            var data = _mapper.Map<MovieDetailsDto>(movie);
            return data;
        }

        public async Task<MovieDetailsDto> CreateAsync(MovieDto dto)
        {
            using var dataStream = new MemoryStream();
            await dto.Poster.CopyToAsync(dataStream);

            var movie = _mapper.Map<Movie>(dto);

            movie.Poster = dataStream.ToArray();

            await _unitOfWork.Movies.CreateAsync(movie);
            await _unitOfWork.CompleteAsync();

            var createdMovie = _mapper.Map<MovieDetailsDto>(movie);
            return createdMovie;
        }

        public async Task<MovieDetailsDto> UpdateAsync(int id, MovieDto dto)
        {
            var movieIsExisting = await _unitOfWork.Movies.GetByIdAsync(id);
            if (movieIsExisting == null)
                return null;

            _mapper.Map(dto, movieIsExisting);

            if (dto.Poster != null)
            {
                using var dataStream = new MemoryStream();
                await dto.Poster.CopyToAsync(dataStream);
                movieIsExisting.Poster = dataStream.ToArray();
            }

            _unitOfWork.Movies.Update(movieIsExisting);
            await _unitOfWork.CompleteAsync();

            var updatedMovie = _mapper.Map<MovieDetailsDto>(movieIsExisting);
            return updatedMovie;
        }


        public async Task<MovieDetailsDto> DeleteAsync(int id)
        {
            var movie = await _unitOfWork.Movies.GetByIdAsync(id);
            if (movie == null)
                return null;

            await _unitOfWork.Movies.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            var deletedMovie = _mapper.Map<MovieDetailsDto>(movie);
            return deletedMovie;
        }
    }
}
