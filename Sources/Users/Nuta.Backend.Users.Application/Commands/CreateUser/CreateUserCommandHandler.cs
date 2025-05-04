using MediatR;
using Nuta.Backend.Users.Domain.Aggregates;
using Nuta.Backend.Users.Domain.Repositories;

namespace Nuta.Backend.Users.Application.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Name);
        
        userRepository.Add(user);
        await userRepository.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}