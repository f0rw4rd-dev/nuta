using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuta.Backend.Products.Application.Dtos;
using Nuta.Backend.Products.Application.Queries.GetProductShortInfoList;

namespace Nuta.Backend.API.Controllers.Products;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "ProductsModuleV1")]
[Route("api/products/v{version:apiVersion}/[controller]")]
public class ManufacturerController(IMediator mediator) : ControllerBase
{
}