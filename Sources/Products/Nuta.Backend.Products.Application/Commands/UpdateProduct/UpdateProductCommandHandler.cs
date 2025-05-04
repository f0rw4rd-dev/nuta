using MediatR;
using Nuta.Backend.Products.Domain.Exceptions;
using Nuta.Backend.Products.Domain.Repositories;

namespace Nuta.Backend.Products.Application.Commands.UpdateProduct;

public class UpdateProductCommandHandler(
    IProductRepository productRepository,
    IManufacturerRepository manufacturerRepository)
    : IRequestHandler<UpdateProductCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken)
                      ?? throw new ProductNotFoundException(request.ProductId);

        if (request.Name.HasValue)
            product.SetName(request.Name.Value);

        if (request.Description.HasValue)
            product.SetDescription(request.Description.Value);

        if (request.Ean13.HasValue)
            product.SetDescription(request.Description.Value);

        if (request.ImageKey.HasValue)
        {
            if (request.ImageKey.Value is null)
                product.ClearImage();
            else
                product.SetImage(request.ImageKey.Value);
        }

        if (request.Category.HasValue)
            product.SetCategory(request.Category.Value);

        if (request.SubCategory.HasValue)
            product.SetSubCategory(request.SubCategory.Value);

        if (request.ManufacturerId.HasValue)
        {
            var manufacturer = await manufacturerRepository.GetByIdAsync(
                                   request.ManufacturerId.Value,
                                   cancellationToken)
                               ?? throw new ManufacturerNotFoundException(request.ManufacturerId.Value);

            product.SetManufacturer(manufacturer);
        }

        if (request.NutritionFacts.HasValue)
            product.SetNutritionFacts(request.NutritionFacts.Value);

        if (request.Ingredients.HasValue)
            product.SetIngredients(request.Ingredients.Value);

        if (request.Labels.HasValue)
        {
            if (request.Labels.Value is null)
                product.ClearLabels();
            else
                product.SetLabels(request.Labels.Value);
        }

        if (request.ExternalScores.HasValue)
            product.SetExternalScores(request.ExternalScores.Value);

        await productRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}