using Microsoft.Extensions.DependencyInjection;
using Nuta.Users.Domain.Repositories;
using Nuta.Users.Infrastructure.Persistence.Repositories;

namespace Nuta.Users.Infrastructure.DependencyInjection;

internal static class RepositoriesServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}