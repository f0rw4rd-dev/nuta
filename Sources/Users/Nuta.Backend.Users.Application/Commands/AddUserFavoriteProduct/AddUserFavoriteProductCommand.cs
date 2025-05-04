using MediatR;

namespace Nuta.Backend.Users.Application.Commands.AddUserFavoriteProduct;

public record AddUserFavoriteProductCommand(Guid UserId, Guid ProductId) : IRequest<Unit>;