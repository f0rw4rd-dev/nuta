using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Users.Domain.Repositories;
using Nuta.Backend.Users.Infrastructure.Repositories;

namespace Nuta.Backend.Users.Infrastructure.DependencyInjection;

internal static class RepositoriesServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}