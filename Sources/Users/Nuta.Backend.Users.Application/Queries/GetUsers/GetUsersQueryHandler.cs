using MediatR;
using Nuta.Backend.Users.Application.Dtos;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Queries.GetUsers;

public class GetUsersQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUsersQuery, IReadOnlyCollection<UserDto>>
{
    public async Task<IReadOnlyCollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetListAsync(request.Pagination, cancellationToken);
        
        return users.Select(x => new UserDto(x.Id, x.Name, x.FoodPreferences)).ToArray();
    }
}