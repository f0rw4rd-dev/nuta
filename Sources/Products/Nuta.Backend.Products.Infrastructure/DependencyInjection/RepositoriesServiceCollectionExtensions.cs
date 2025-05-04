using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Products.Domain.Repositories;
using Nuta.Backend.Products.Infrastructure.Repositories;

namespace Nuta.Backend.Products.Infrastructure.DependencyInjection;

internal static class RepositoriesServiceCollectionExtensions
{
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IAdditiveRepository, AdditiveRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

        return services;
    }
}