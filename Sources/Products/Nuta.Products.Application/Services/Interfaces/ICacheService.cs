namespace Nuta.Products.Application.Services.Interfaces;

public interface ICacheService
{
    Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpiration = null);
    
    Task<T?> GetAsync<T>(string key);
    
    Task RemoveAsync(string key);
}