using Api.Controllers.ProductsControllers.Dtos;
using Domain.Entities;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

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
        ProductView productView = ProductView.FromGetProductDto(product);
        return CreatedAtRoute(nameof(GetProductsController.GetProductById), new {Id = product.Id}, productView);
    }
}