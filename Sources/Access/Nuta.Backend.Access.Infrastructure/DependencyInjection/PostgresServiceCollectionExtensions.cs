using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nuta.Backend.Access.Options;
using Nuta.Backend.Access.Infrastructure.Postgres;

namespace Nuta.Backend.Access.Infrastructure.DependencyInjection;

internal static class PostgresServiceCollectionExtensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        services.AddDbContext<AccessModuleDbContext>((serviceProvider, options) =>
        {
            var accessModuleOptions = serviceProvider.GetRequiredService<IOptions<AccessModuleOptions>>().Value;
            var postgresOptions = accessModuleOptions.Postgres;

            options.UseNpgsql(postgresOptions.ConnectionString);
            options.UseSnakeCaseNamingConvention();
            options.UseOpenIddict();
        });

        return services;
    }
}