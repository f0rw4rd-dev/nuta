namespace Nuta.Backend.Products.Domain.Exceptions;

public class AdditiveNotFoundException : EntityNotFoundException
{
    public AdditiveNotFoundException(Guid additiveId)
        : base($"Добавка не найдена. AdditiveId = {additiveId}")
    {
    }
}