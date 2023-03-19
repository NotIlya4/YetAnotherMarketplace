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
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ProductView>> CreateProduct(CreateProductCommandView createProductCommandDto)
    {
        Product product = await ProductService.CreateNewProduct(createProductCommandDto.ToCreateProductDto());
        ProductView productView = ProductView.FromProduct(product);
        return CreatedAtRoute(nameof(GetProductsController.GetProductByName), new {Name = product.Name.Value}, productView);
    }
}