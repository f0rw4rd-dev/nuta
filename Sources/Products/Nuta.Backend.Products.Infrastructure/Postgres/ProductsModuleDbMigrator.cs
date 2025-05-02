using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Nuta.Backend.Products.Infrastructure.Postgres;

public static class ProductsModuleDbMigrator
{
    public static async Task MigrateUp(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductsModuleDbContext>();
        
        await dbContext.Database.MigrateAsync();
    }
}