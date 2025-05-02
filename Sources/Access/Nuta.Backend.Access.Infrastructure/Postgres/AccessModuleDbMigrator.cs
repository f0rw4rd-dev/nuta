using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Nuta.Backend.Access.Infrastructure.Postgres;

public class AccessModuleDbMigrator
{
    public static async Task MigrateUp(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AccessModuleDbContext>();
        
        await dbContext.Database.MigrateAsync();
    }
}