using Nuta.Backend.Users.Application.Dtos;

namespace Nuta.Backend.Users.Application.Models.Responses;

public record GetUserViewedProductsResponse(IReadOnlyCollection<UserViewedProductDto> ViewedProducts);