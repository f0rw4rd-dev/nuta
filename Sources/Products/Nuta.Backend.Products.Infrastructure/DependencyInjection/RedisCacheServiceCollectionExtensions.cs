using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Products.Options;

namespace Nuta.Backend.Products.Infrastructure.DependencyInjection;

internal static class RedisCacheServiceCollectionExtensions
{
    internal static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
    {
        var redisCacheOptions = configuration
            .GetSection("ProductsModuleOptions:RedisCacheOptions")
            .Get<RedisCacheOptions>();
        
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisCacheOptions!.Configuration;
            options.InstanceName = redisCacheOptions.InstanceName;
        });

        return services;
    }
}