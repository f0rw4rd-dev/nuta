using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Access.Application.Services.Interfaces;
using Nuta.Backend.Access.Infrastructure.Services;
using Nuta.Backend.Access.Options;

namespace Nuta.Backend.Access.Infrastructure.DependencyInjection;

public static class AccessModuleServiceCollectionExtensions
{
    public static IServiceCollection AddAccessModule(
        this IServiceCollection services, 
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        services.AddOptions<AccessModuleOptions>()
            .Bind(configuration.GetSection("AccessModule"))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        services.AddPostgres();
        services.AddRepositories();
        services.AddAccess(environment);

        services.AddScoped<IIdentityUserService, IdentityUserService>();

        return services;
    }
}