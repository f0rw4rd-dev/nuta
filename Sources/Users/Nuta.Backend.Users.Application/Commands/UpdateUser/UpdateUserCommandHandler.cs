using MediatR;
using Nuta.Backend.Users.Domain.Exceptions;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(request.UserId, cancellationToken)
                   ?? throw new UserNotFoundException(request.UserId);

        if (request.Name is not null)
            user.SetName(request.Name);

        if (request.FoodPreferences is not null)
            user.SetFoodPreferences(request.FoodPreferences);

        await userRepository.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}