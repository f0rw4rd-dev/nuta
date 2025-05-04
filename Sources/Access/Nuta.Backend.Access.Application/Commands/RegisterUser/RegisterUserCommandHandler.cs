using MediatR;
using Nuta.Backend.Access.Application.Services.Interfaces;

namespace Nuta.Backend.Access.Application.Commands.RegisterUser;

public class RegisterUserCommandHandler(IIdentityUserService identityUserService)
    : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        //TODO: Проверка входных данных

        var userId = await identityUserService.RegisterAsync(
            request.Email,
            request.Password,
            request.Roles,
            cancellationToken);

        return userId;
    }
}