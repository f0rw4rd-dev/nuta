using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Products.Options;

namespace Nuta.Backend.Products.Infrastructure.DependencyInjection;

public static class ProductsModuleServiceCollectionExtensions
{
    public static IServiceCollection AddProductsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ProductsModuleOptions>()
            .Bind(configuration.GetSection("ProductsModule"))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        services.AddPostgres();
        services.AddRedisCache(configuration);
        services.AddRepositories();

        return services;
    }
}