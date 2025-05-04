using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Models.Responses;

public record SearchProductsResponse(IReadOnlyCollection<ProductPreviewDto> Products);