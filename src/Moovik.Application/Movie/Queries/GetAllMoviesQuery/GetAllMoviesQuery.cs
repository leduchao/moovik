using MediatR;
using Moovik.Domain.Repositories;
using Moovik.Domain.Shared;

namespace Moovik.Application.Movie.Queries.GetAllMoviesQuery;

public class GetAllMoviesQuery : IRequest<Result<List<Domain.Entities.Movie>>>
{
}

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, Result<List<Domain.Entities.Movie>>>
{
    private readonly IMovieRepository _movieRepository;

    public GetAllMoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Result<List<Domain.Entities.Movie>>> Handle(
        GetAllMoviesQuery request,
        CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetAllMovies(cancellationToken);
        return Result<List<Domain.Entities.Movie>>.Success(movies);
    }
}
