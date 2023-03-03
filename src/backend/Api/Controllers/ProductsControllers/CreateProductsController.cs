using Infrastructure.ProductService;
using Infrastructure.ProductService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

public class CreateProductsController : ProductsControllerBase
{
    public CreateProductsController(IProductService productService) : base(productService)
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GetProductDto>> CreateProduct(CreateProductDto createProductDto)
    {
        GetProductDto getProductDto = await ProductService.CreateNewProduct(createProductDto);
        return CreatedAtRoute(nameof(GetProductsController.GetProductById), new {Id = getProductDto.Id}, getProductDto);
    }
}