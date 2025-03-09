using MoviesApi.Data;
using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Genre> Genres { get; }
        public IGenericRepository<Movie> Movies { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Genres = new GenericRepository<Genre>(_context);
            Movies = new GenericRepository<Movie>(_context);
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
