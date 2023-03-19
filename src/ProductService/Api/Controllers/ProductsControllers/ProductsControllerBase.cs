using Api.Controllers.Attributes;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[ApiController]
[Route("api/products")]
[ProducesInternalException]
public class ProductsControllerBase : ControllerBase
{
    protected readonly IProductService ProductService;

    public ProductsControllerBase(IProductService productService)
    {
        ProductService = productService;
    }
}