namespace Nuta.Backend.Users.Domain.Exceptions;

public class UserNotFoundException : EntityNotFoundException
{
    public UserNotFoundException(Guid userId)
        : base($"Пользователь не найден. UserId = {userId}")
    {
    }
}