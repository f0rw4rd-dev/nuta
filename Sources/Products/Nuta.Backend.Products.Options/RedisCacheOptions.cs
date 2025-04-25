namespace Nuta.Backend.Products.Options;

public class RedisCacheOptions
{
    public required string Configuration { get; init; }
    
    public required string InstanceName { get; init; }
}