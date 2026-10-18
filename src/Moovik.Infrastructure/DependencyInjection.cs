using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moovik.Domain.Repositories;
using Moovik.Infrastructure.Persistence;
using Moovik.Infrastructure.Repositories;

namespace Moovik.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>();

        services.AddScoped<IMovieRepository, MovieRepository>();
        // services.AddScoped<IUnitOfWork>();

        return services;
    }
}
