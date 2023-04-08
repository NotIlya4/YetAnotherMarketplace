using Api.ProducesAttributes;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[ApiController]
[Route("api/products")]
[ProducesInternalException]
public class ProductsControllerBase : ControllerBase
{

}