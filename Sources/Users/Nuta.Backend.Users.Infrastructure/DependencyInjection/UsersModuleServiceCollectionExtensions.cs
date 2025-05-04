using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Users.Application.Dtos;
using Nuta.Backend.Users.Options;

namespace Nuta.Backend.Users.Infrastructure.DependencyInjection;

public static class UsersModuleServiceCollectionExtensions
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<UsersModuleOptions>()
            .Bind(configuration.GetSection("UsersModule"))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<UserDto>());

        services.AddPostgres();
        services.AddRepositories();
        services.AddQuartz();

        return services;
    }
}