using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nuta.Backend.API.Controllers.Products;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "ProductsModuleV1")]
[Route("api/products/v{version:apiVersion}/[controller]")]
public class ManufacturersController(IMediator mediator) : ControllerBase
{
}