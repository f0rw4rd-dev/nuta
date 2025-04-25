using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Products.Domain.Repositories;
using Nuta.Backend.Products.Infrastructure.Persistence.Repositories;

namespace Nuta.Backend.Products.Infrastructure.DependencyInjection;

internal static class RepositoriesServiceCollectionExtensions
{
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}