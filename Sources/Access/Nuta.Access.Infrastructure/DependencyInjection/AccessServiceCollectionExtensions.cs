using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuta.Access.Domain.Entities;
using Nuta.Access.Infrastructure.Persistence.Relational;
using IdentityRole = Nuta.Access.Domain.Entities.IdentityRole;
using IdentityUser = Nuta.Access.Domain.Entities.IdentityUser;

namespace Nuta.Access.Infrastructure.DependencyInjection;

internal static class AccessServiceCollectionExtensions
{
    public static IServiceCollection AddAccess(this IServiceCollection services)
    {
        services
            .AddIdentityCore<IdentityUser>(identityOptions =>
            {
                identityOptions.Password.RequiredLength = 8;
                identityOptions.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AccessModuleDbContext>()
            .AddDefaultTokenProviders();

        services
            .AddOpenIddict()
            .AddCore(openIddictCoreBuilder => openIddictCoreBuilder
                .UseEntityFrameworkCore()
                .UseDbContext<AccessModuleDbContext>())
            .AddServer(openIddictServerBuilder =>
            {
                openIddictServerBuilder.SetTokenEndpointUris("/connect/token")
                    .AllowPasswordFlow()
                    .AcceptAnonymousClients()
                    .UseAspNetCore()
                    .EnableTokenEndpointPassthrough();
            })
            .AddValidation(openIddictValidationBuilder =>
            {
                openIddictValidationBuilder.UseLocalServer();
                openIddictValidationBuilder.UseAspNetCore();
            });

        return services;
    }
}