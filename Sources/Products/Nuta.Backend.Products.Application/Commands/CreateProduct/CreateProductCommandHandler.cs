using MediatR;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Exceptions;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IProductRepository productRepository,
    IManufacturerRepository manufacturerRepository)
    : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await manufacturerRepository.GetByIdAsync(request.ManufacturerId, cancellationToken)
                           ?? throw new ManufacturerNotFoundException(request.ManufacturerId);

        var product = Product.Create(
            request.Name,
            request.Description,
            request.Ean13,
            request.ImageKey,
            request.Category,
            request.SubCategory,
            manufacturer,
            request.NutritionFacts,
            request.Ingredients,
            request.Labels,
            request.ExternalScores);

        productRepository.Add(product);
        await productRepository.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}