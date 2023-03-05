using Api.Controllers.ProductsControllers.Dtos;
using Infrastructure.Services.ProductService;
using Infrastructure.Services.ProductService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

public class CreateProductsController : ProductsControllerBase
{
    public CreateProductsController(IProductService productService) : base(productService)
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GetProductView>> CreateProduct(CreateProductView createProductDto)
    {
        GetProductDto productDto = await ProductService.CreateNewProduct(createProductDto.ToCreateProductDto());
        GetProductView productView = GetProductView.FromGetProductDto(productDto);
        return CreatedAtRoute(nameof(GetProductsController.GetProductById), new {Id = productDto.Id}, productView);
    }
}