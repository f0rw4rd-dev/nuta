using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuta.Backend.Access.Domain.Entities;
using Nuta.Backend.Access.Infrastructure.Persistence.Relational;
using IdentityRole = Nuta.Backend.Access.Domain.Entities.IdentityRole;
using IdentityUser = Nuta.Backend.Access.Domain.Entities.IdentityUser;

namespace Nuta.Backend.Access.Infrastructure.DependencyInjection;

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