namespace Nuta.Backend.Access.Application.Models.Requests;

public record RegisterUserRequest(string Email, string Password, IReadOnlyCollection<string> Roles);