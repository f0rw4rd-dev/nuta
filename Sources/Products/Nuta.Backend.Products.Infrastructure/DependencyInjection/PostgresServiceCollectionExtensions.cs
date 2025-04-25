using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nuta.Backend.BuildingBlocks.Infrastructure;
using Nuta.Backend.BuildingBlocks.Infrastructure.ValueConverters;
using Nuta.Backend.Products.Infrastructure.Persistence.Relational;
using Nuta.Backend.Products.Options;

namespace Nuta.Backend.Products.Infrastructure.DependencyInjection;

internal static class PostgresServiceCollectionExtensions
{
    internal static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        services.AddDbContext<ProductsModuleDbContext>((serviceProvider, options) =>
        {
            var productsModuleOptions = serviceProvider.GetRequiredService<IOptions<ProductsModuleOptions>>().Value;
            var postgresOptions = productsModuleOptions.Postgres;

            options.UseNpgsql(postgresOptions.ConnectionString);
            options.UseSnakeCaseNamingConvention();
            options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
        }); 

        return services;
    }
}