using Microsoft.AspNetCore.Identity;

namespace Nuta.Backend.Access.Domain.Exceptions;

public class UserRegistrationFailedException : Exception
{
    public UserRegistrationFailedException(Guid userId, string email, IEnumerable<IdentityError> errors)
        : base($"Регистрация пользователя провалена. " +
               $"UserId = {userId.ToString()}, " +
               $"Email = {email}, " +
               $"Errors = {string.Join(", ", errors.Select(error => error.Description))}")
    {
    }
}