using MediatR;

namespace Nuta.Backend.Users.Application.Commands.RemoveUserFavoriteProduct;

public record RemoveUserFavoriteProductCommand(Guid UserId, Guid ProductId) : IRequest<Unit>;