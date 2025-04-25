namespace Nuta.Backend.Access.Options;

public class PostgresOptions
{
    public required string ConnectionString { get; init; }
    
    public required string Schema { get; init; }
}