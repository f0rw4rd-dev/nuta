using MediatR;

namespace Nuta.Backend.Access.Application.Commands.RegisterUser;

public record RegisterUserCommand(
    string Email,
    string Password,
    IReadOnlyCollection<string> Roles)
    : IRequest<Guid>;