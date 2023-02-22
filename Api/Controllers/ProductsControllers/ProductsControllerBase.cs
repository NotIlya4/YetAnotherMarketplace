using Infrastructure.ExceptionCatching.ExceptionMappers.BadResponseDtos;
using Infrastructure.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[ApiController]
[Route("api/Products")]
[ProducesResponseType(typeof(BadResponseDto), StatusCodes.Status500InternalServerError)]
public class ProductsControllerBase : ControllerBase
{
    protected IProductService ProductService { get; }

    public ProductsControllerBase(IProductService productService)
    {
        ProductService = productService;
    }
}