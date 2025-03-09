namespace MoviesApi.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<Movie> Movies { get; }
        Task CompleteAsync();
    }
}
