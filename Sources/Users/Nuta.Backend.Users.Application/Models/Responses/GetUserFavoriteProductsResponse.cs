using Nuta.Backend.Users.Application.Dtos;

namespace Nuta.Backend.Users.Application.Models.Responses;

public record GetUserFavoriteProductsResponse(IReadOnlyCollection<UserFavoriteProductDto> FavoriteProducts);