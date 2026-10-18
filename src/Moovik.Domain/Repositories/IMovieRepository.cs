using Moovik.Domain.Entities;

namespace Moovik.Domain.Repositories;

public interface IMovieRepository
{
    Task<List<Movie>> GetAllMovies(CancellationToken cancellationToken);
    Task<Movie?> GetMovieById(int id, CancellationToken cancellationToken);
    Task<int> AddMovie(Movie movie, CancellationToken cancellationToken);
}
