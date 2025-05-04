using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Products.Domain.Enums;

namespace Nuta.Backend.Products.Application.Models;

public record ProductFilter(Optional<ProductCategory> Category, Optional<ProductSubCategory> SubCategory);