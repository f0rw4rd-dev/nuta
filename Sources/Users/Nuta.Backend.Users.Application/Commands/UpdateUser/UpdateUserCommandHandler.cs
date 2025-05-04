using MediatR;
using Nuta.Backend.Users.Domain.Exceptions;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken)
                   ?? throw new UserNotFoundException(request.UserId);

        //TODO: Некоторые поля должны быть обязательными, необходимо это проверять через FluentValidation
        if (request.Name.HasValue)
            user.SetName(request.Name.Value);

        if (request.FoodPreferences.HasValue)
            user.SetFoodPreferences(request.FoodPreferences.Value);

        await userRepository.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}