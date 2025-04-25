using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuta.Users.Infrastructure.DependencyInjection;
using Nuta.Users.Options;

namespace Nuta.Users.Infrastructure.DependencyInjection;

public static class UsersModuleServiceCollectionExtensions
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<UsersModuleOptions>()
            .Bind(configuration.GetSection("UsersModule"))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        services.AddPostgres();
        services.AddRepositories();
        services.AddQuartz();

        return services;
    }
}