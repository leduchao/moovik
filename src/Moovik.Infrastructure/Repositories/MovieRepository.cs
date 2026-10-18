using Microsoft.EntityFrameworkCore;
using Moovik.Domain.Entities;
using Moovik.Domain.Repositories;
using Moovik.Infrastructure.Persistence;

namespace Moovik.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _dbContext;

    public MovieRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddMovie(Movie movie, CancellationToken cancellationToken)
    {
        var dbModel = new Persistence.DatabaseModels.Movie
        {
            Name = movie.Name,
            Imdb = movie.Imdb,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow
        };

        await _dbContext.Movies.AddAsync(dbModel, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return dbModel.Id;
    }

    public async Task<List<Movie>> GetAllMovies(CancellationToken cancellationToken)
    {
        return await _dbContext.Movies
            .AsNoTracking()
            .Where(p => !p.IsDeleted)
            .Select(p => new Movie(p.Id, p.Name, p.Imdb))
            .ToListAsync(cancellationToken);
    }

    public async Task<Movie?> GetMovieById(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Movies
            .AsNoTracking()
            .Where(p => !p.IsDeleted && p.Id == id)
            .Select(p => new Movie(p.Id, p.Name, p.Imdb))
            .SingleOrDefaultAsync(cancellationToken);
    }
}
