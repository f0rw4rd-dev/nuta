namespace Nuta.Backend.Products.Domain.Exceptions;

public class ProductNotFoundException : EntityNotFoundException
{
    public ProductNotFoundException(Guid productId)
        : base($"Продукт не найден. ProductId = {productId}")
    {
    }

    public ProductNotFoundException(string ean13)
        : base($"Продукт не найден. Ean13 = {ean13}")
    {
    }
}