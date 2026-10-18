using FluentValidation;

namespace Moovik.Application.Movie.Commands.AddMovie;

public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
{
    public AddMovieCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(x => x.Imdb)
            .InclusiveBetween(0m, 10m);
    }
}
