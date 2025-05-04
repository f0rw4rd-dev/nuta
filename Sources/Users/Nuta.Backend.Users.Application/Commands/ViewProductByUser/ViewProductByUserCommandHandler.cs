using MediatR;
using Nuta.Backend.Users.Domain.Exceptions;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Commands.ViewProductByUser;

public class ViewProductByUserCommandHandler(IUserRepository userRepository)
    : IRequestHandler<ViewProductByUserCommand, Unit>
{
    public async Task<Unit> Handle(ViewProductByUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId, cancellationToken)
                   ?? throw new UserNotFoundException(request.UserId);

        user.ViewProduct(request.ProductId);
        await userRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}