using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nuta.Backend.Access.Infrastructure.Postgres;
using IdentityRole = Nuta.Backend.Access.Domain.Entities.IdentityRole;
using IdentityUser = Nuta.Backend.Access.Domain.Entities.IdentityUser;

namespace Nuta.Backend.Access.Infrastructure.DependencyInjection;

internal static class AccessServiceCollectionExtensions
{
    public static IServiceCollection AddAccess(this IServiceCollection services, IWebHostEnvironment environment)
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
                    .AddDevelopmentEncryptionCertificate()
                    .AddDevelopmentSigningCertificate()
                    .UseAspNetCore()
                    .EnableTokenEndpointPassthrough();

                if (environment.IsDevelopment())
                {
                    openIddictServerBuilder
                        .AddDevelopmentEncryptionCertificate()
                        .AddDevelopmentSigningCertificate();
                }
                else
                {
                    //TODO: AddEncryptionCertificate(...) + AddSigningCertificate(...)
                }
            })
            .AddValidation(openIddictValidationBuilder =>
            {
                openIddictValidationBuilder.UseLocalServer();
                openIddictValidationBuilder.UseAspNetCore();
            });

        return services;
    }
}