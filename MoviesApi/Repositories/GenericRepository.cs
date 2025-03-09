


namespace MoviesApi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IQueryable<T> GetAll() => _dbSet.AsQueryable();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task CreateAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public async Task DeleteAsync(int id) => _dbSet.Remove(await _dbSet.FindAsync(id));
    }
}