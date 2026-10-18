using MediatR;

using Moovik.Domain.Repositories;
using Moovik.Domain.Shared;

namespace Moovik.Application.Movie.Commands.AddMovie;

public class AddMovieCommand : IRequest<Result<int>>
{
    public string Name { get; set; }
    public decimal Imdb { get; set; }

    public AddMovieCommand(string name, decimal imdb)
    {
        Name = name;
        Imdb = imdb;
    }
}

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Result<int>>
{
    private readonly IMovieRepository _movieRepository;

    public AddMovieCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Result<int>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        var newMovie = new Domain.Entities.Movie(request.Name, request.Imdb);
        var newMovieId = await _movieRepository.AddMovie(newMovie, cancellationToken);

        return newMovieId > 0
            ? Result<int>.Success(newMovieId, "Add movie successfully")
            : Result<int>.Failure(new Error("movie.add_movie_failed", "Add new movie failed"));
    }
}
