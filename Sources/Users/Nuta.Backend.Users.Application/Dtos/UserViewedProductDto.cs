namespace Nuta.Backend.Users.Application.Dtos;

public record UserViewedProductDto(Guid ProductId, DateTime ViewedAt);