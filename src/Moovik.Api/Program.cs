using MediatR;
using Moovik.Application;
using Moovik.Application.Movie.Commands.AddMovie;
using Moovik.Application.Movie.Queries.GetAllMoviesQuery;
using Moovik.Application.Movie.Queries.GetMovieByIdQuery;
using Moovik.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", async (ISender sender, CancellationToken cancellationToken) =>
{
    var result = await sender.Send(new GetAllMoviesQuery(), cancellationToken);
    return Results.Ok(result);
});

app.MapGet("/{id:int}", async (int id, ISender sender, CancellationToken cancellationToken) =>
{
    var result = await sender.Send(new GetMovieByIdQuery(id), cancellationToken);
    return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
});

app.MapPost("/", async (AddMovieCommand command, ISender sender, CancellationToken cancellationToken) =>
{
    var result = await sender.Send(command, cancellationToken);
    return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
});

app.Run();
