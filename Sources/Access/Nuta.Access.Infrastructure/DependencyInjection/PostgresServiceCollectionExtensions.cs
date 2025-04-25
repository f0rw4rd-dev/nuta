using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nuta.BuildingBlocks.Infrastructure;
using Nuta.Access.Infrastructure.Persistence.Relational;
using Nuta.Access.Options;
using Nuta.BuildingBlocks.Infrastructure.ValueConverters;

namespace Nuta.Access.Infrastructure.DependencyInjection;

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
            options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
            options.UseOpenIddict();
        });

        return services;
    }
}