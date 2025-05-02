using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nuta.Backend.Users.Infrastructure.Postgres;
using Nuta.Backend.Users.Options;

namespace Nuta.Backend.Users.Infrastructure.DependencyInjection;

internal static class PostgresServiceCollectionExtensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        services.AddDbContext<UsersModuleDbContext>((serviceProvider, options) =>
        {
            var usersModuleOptions = serviceProvider.GetRequiredService<IOptions<UsersModuleOptions>>().Value;
            var postgresOptions = usersModuleOptions.Postgres;

            options.UseNpgsql(postgresOptions.ConnectionString);
            options.UseSnakeCaseNamingConvention();
        });

        return services;
    }
}