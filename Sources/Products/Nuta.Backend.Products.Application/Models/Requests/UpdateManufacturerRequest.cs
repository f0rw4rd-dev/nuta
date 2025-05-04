using Nuta.Backend.BuildingBlocks.Application.Structs;

namespace Nuta.Backend.Products.Application.Models.Requests;

public record UpdateManufacturerRequest(
    Guid ManufacturerId,
    Optional<string> Name,
    Optional<string?> Description);