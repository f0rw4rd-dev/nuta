namespace Nuta.Backend.Access.Domain.Exceptions;

public class IdentityUserNotFoundException : EntityNotFoundException
{
    public IdentityUserNotFoundException(Guid userId)
        : base($"Пользователь не найден. UserId = {userId}")
    {
    }
}