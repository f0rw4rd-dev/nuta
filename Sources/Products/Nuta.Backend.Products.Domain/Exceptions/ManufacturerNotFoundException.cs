namespace Nuta.Backend.Products.Domain.Exceptions;

public class ManufacturerNotFoundException : EntityNotFoundException
{
    public ManufacturerNotFoundException(Guid manufacturerId)
        : base($"Производитель не найден. ManufacturerId = {manufacturerId}")
    {
    }
}