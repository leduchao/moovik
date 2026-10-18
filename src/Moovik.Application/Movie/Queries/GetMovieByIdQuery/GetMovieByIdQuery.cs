using MediatR;
using Moovik.Domain.Repositories;
using Moovik.Domain.Shared;

namespace Moovik.Application.Movie.Queries.GetMovieByIdQuery;

public class GetMovieByIdQuery : IRequest<Result<Domain.Entities.Movie>>
{
    public int Id { get; set; }

    public GetMovieByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Result<Domain.Entities.Movie>>
{
    private readonly IMovieRepository _movieRepository;

    public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Result<Domain.Entities.Movie>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetMovieById(request.Id, cancellationToken);
        return movie is null
            ? Result<Domain.Entities.Movie>.Failure(
                new Error("movie.not_found", $"Movie not found with id={request.Id}"))
            : Result<Domain.Entities.Movie>.Success(movie);
    }
}
