using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nuta.Backend.BuildingBlocks.Infrastructure;
using Nuta.Backend.Access.Options;
using Nuta.Backend.Access.Infrastructure.Persistence.Relational;
using Nuta.Backend.BuildingBlocks.Infrastructure.ValueConverters;

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
            options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
            options.UseOpenIddict();
        });

        return services;
    }
}