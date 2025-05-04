namespace Nuta.Backend.Access.Application.Services.Interfaces;

public interface IIdentityUserService
{
    Task<Guid> RegisterAsync(
        string email,
        string password,
        IReadOnlyCollection<string> roles,
        CancellationToken cancellationToken);
    
    Task<bool> ValidateCredentialsAsync(string email, string password, CancellationToken cancellationToken);

    Task AddToRolesAsync(Guid userId, IReadOnlyCollection<string> roles, CancellationToken cancellationToken);

    Task RemoveFromRolesAsync(Guid userId, IReadOnlyCollection<string> roles, CancellationToken cancellationToken);
    
    Task<IReadOnlyCollection<string>> GetRolesAsync(Guid userId);
}