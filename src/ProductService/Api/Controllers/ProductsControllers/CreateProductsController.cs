using Api.Controllers.Attributes;
using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
public class CreateProductsController : ProductsControllerBase
{
    public CreateProductsController(IProductService productService) : base(productService)
    {
    }

    [HttpPost]
    [ProducesOk]
    public async Task<ActionResult<ProductView>> CreateProduct(CreateProductCommandView createProductCommandDto)
    {
        Product product = await ProductService.CreateNewProduct(createProductCommandDto.ToCreateProductDto());
        ProductView productView = ProductView.FromProduct(product);
        return Ok(productView);
    }
}