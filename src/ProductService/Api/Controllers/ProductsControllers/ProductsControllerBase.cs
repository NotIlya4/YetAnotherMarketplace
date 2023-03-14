using Api.Controllers.Attributes;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[ApiController]
[Route("api/Products")]
[ProducesInternalException]
public class ProductsControllerBase : ControllerBase
{
    protected IProductService ProductService { get; }

    public ProductsControllerBase(IProductService productService)
    {
        ProductService = productService;
    }
}