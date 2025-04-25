using Microsoft.Extensions.DependencyInjection;
using Nuta.Products.Domain.Repositories;
using Nuta.Products.Infrastructure.Persistence.Repositories;

namespace Nuta.Products.Infrastructure.DependencyInjection;

internal static class RepositoriesServiceCollectionExtensions
{
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}