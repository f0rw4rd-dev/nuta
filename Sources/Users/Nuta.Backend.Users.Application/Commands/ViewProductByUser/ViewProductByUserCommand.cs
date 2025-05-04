using MediatR;

namespace Nuta.Backend.Users.Application.Commands.ViewProductByUser;

public record ViewProductByUserCommand(Guid UserId, Guid ProductId) : IRequest<Unit>;