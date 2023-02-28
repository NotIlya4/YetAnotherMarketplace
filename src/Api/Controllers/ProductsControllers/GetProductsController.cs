using Api.ProducesResponseTypeAttributes;
using Infrastructure.ProductService;
using Infrastructure.ProductService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

public class GetProductsController : ProductsControllerBase
{
    public GetProductsController(IProductService productService) : base(productService)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GetProductDto>>> GetProducts()
    {
        return Ok(await ProductService.GetProducts());
    }

    [HttpGet]
    [Route("id/{id}", Name = nameof(GetProductById))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesEntityNotFound]
    public async Task<ActionResult<GetProductDto>> GetProductById(string id)
    {
        return Ok(await ProductService.GetProductById(id));
    }

    [HttpGet]
    [Route("name/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesEntityNotFound]
    public async Task<ActionResult<GetProductDto>> GetProductByName(string name)
    {
        return Ok(await ProductService.GetProductByName(name));
    }
}