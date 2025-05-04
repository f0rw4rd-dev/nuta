using MediatR;
using Nuta.Backend.Users.Application.Dtos;
using Nuta.Backend.Users.Domain.Exceptions;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Queries.GetUser;

public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
            throw new UserNotFoundException(request.UserId);

        return new UserDto(user.Id, user.Name, user.FoodPreferences);
    }
}