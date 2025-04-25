using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Nuta.Access.Infrastructure.Persistence.Relational;

public class AccessModuleDbMigrator
{
    public static async Task MigrateUp(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AccessModuleDbContext>();
        
        await dbContext.Database.MigrateAsync();
    }
}