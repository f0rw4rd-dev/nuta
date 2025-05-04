using MediatR;
using Nuta.Backend.Users.Domain.Exceptions;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Commands.AddUserFavoriteProduct;

public class AddUserFavoriteProductCommandHandler(IUserRepository userRepository)
    : IRequestHandler<AddUserFavoriteProductCommand, Unit>
{
    public async Task<Unit> Handle(AddUserFavoriteProductCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken)
                   ?? throw new UserNotFoundException(request.UserId);

        user.AddFavoriteProduct(request.ProductId);
        await userRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}