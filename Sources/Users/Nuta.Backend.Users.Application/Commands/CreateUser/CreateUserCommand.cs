using MediatR;

namespace Nuta.Backend.Users.Application.Commands.CreateUser;

public record CreateUserCommand(string Name) : IRequest<Guid>;