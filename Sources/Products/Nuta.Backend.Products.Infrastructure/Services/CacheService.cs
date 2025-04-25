using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Nuta.Backend.Products.Application.Services.Interfaces;

namespace Nuta.Backend.Products.Infrastructure.Services;

public class CacheService(IDistributedCache distributedCache) : ICacheService
{
    public async Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpiration = null)
    {
        var jsonValue = JsonSerializer.Serialize(value);

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromMinutes(30)
        };

        await distributedCache.SetStringAsync(key, jsonValue, options);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var jsonValue = await distributedCache.GetStringAsync(key);
        if (string.IsNullOrEmpty(jsonValue))
            return default;

        try
        {
            return JsonSerializer.Deserialize<T>(jsonValue);
        }
        catch
        {
            return default;
        }
    }

    public async Task RemoveAsync(string key)
    {
        await distributedCache.RemoveAsync(key);
    }
}