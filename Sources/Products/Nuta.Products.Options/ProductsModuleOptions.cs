namespace Nuta.Products.Options;

public class ProductsModuleOptions
{
    public required PostgresOptions Postgres { get; init; }
    
    public required RedisCacheOptions RedisCache { get; init; }
}