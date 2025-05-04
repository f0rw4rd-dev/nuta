namespace Nuta.Backend.Access.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    protected EntityNotFoundException(string message)
        : base(message)
    {
    }

    protected EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}