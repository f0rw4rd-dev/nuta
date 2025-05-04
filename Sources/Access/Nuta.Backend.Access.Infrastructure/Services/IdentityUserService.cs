using Microsoft.AspNetCore.Identity;
using Nuta.Backend.Access.Application.Services.Interfaces;
using Nuta.Backend.Access.Domain.Exceptions;
using IdentityRole = Nuta.Backend.Access.Domain.Entities.IdentityRole;
using IdentityUser = Nuta.Backend.Access.Domain.Entities.IdentityUser;

namespace Nuta.Backend.Access.Infrastructure.Services;

public class IdentityUserService(
    UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager)
    : IIdentityUserService
{
    public async Task<Guid> RegisterAsync(
        string email,
        string password,
        IReadOnlyCollection<string> roles,
        CancellationToken cancellationToken)
    {
        var user = new IdentityUser
        {
            Id = Guid.CreateVersion7(),
            UserName = email,
            Email = email
        };

        var result = await userManager.CreateAsync(user, password);
        
        if (!result.Succeeded)
            throw new UserRegistrationFailedException(user.Id, user.Email, result.Errors);

        foreach (var role in roles.Distinct())
        {
            var roleExists = await roleManager.RoleExistsAsync(role);

            if (!roleExists)
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        await userManager.AddToRolesAsync(user, roles);

        return user.Id;
    }

    public async Task<bool> ValidateCredentialsAsync(
        string email,
        string password,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
            return false;

        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task AddToRolesAsync(
        Guid userId,
        IReadOnlyCollection<string> roles,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(userId.ToString())
                   ?? throw new IdentityUserNotFoundException(userId);

        await userManager.AddToRolesAsync(user, roles);
    }

    public async Task RemoveFromRolesAsync(
        Guid userId,
        IReadOnlyCollection<string> roles,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(userId.ToString())
                   ?? throw new IdentityUserNotFoundException(userId);

        await userManager.RemoveFromRolesAsync(user, roles);
    }

    public async Task<IReadOnlyCollection<string>> GetRolesAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString())
                   ?? throw new IdentityUserNotFoundException(userId);

        var roles = await userManager.GetRolesAsync(user);

        return roles.ToArray();
    }
}