using MediatR;
using Nuta.Backend.Users.Domain.Exceptions;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Commands.RemoveUserFavoriteProduct;

public class RemoveUserFavoriteProductCommandHandler(IUserRepository userRepository)
    : IRequestHandler<RemoveUserFavoriteProductCommand, Unit>
{
    public async Task<Unit> Handle(RemoveUserFavoriteProductCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId, cancellationToken)
                   ?? throw new UserNotFoundException(request.UserId);

        user.RemoveFavoriteProduct(request.ProductId);
        await userRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}