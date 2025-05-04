using Nuta.Backend.Products.Application.Dtos;

namespace Nuta.Backend.Products.Application.Models.Responses;

public record GetProductPreviewsByIdsResponse(IReadOnlyCollection<ProductPreviewDto> Products);