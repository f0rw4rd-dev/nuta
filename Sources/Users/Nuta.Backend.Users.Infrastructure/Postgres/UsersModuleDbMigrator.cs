using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Nuta.Backend.Users.Infrastructure.Postgres;

public static class UsersModuleDbMigrator
{
    public static async Task MigrateUp(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<UsersModuleDbContext>();
        
        await dbContext.Database.MigrateAsync();
    }
}