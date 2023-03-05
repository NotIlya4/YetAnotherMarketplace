using Api.Controllers.ProductsControllers.Dtos;
using Api.ControllersAttributes;
using Domain.Primitives;
using Infrastructure.Repositories.Primitives;
using Infrastructure.Services.ProductService;
using Infrastructure.Services.ProductService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

public class GetProductsController : ProductsControllerBase
{
    public GetProductsController(IProductService productService) : base(productService)
    {
    }

    [HttpGet]
    [ProducesOk]
    [ProducesBadRequest]
    public async Task<ActionResult<List<GetProductView>>> GetProducts(int offset, int limit)
    {
        List<GetProductDto> productDtos = await ProductService.GetProducts(new Pagination(offset, limit));
        List<GetProductView> productViews = productDtos.Select(GetProductView.FromGetProductDto).ToList();
        return Ok(productViews);
    }

    [HttpGet]
    [Route("id/{id}", Name = nameof(GetProductById))]
    [ProducesOk]
    [ProducesNotFound]
    public async Task<ActionResult<GetProductView>> GetProductById(Guid id)
    {
        GetProductDto productDto = await ProductService.GetProductById(id);
        GetProductView productView = GetProductView.FromGetProductDto(productDto);
        return Ok(productView);
    }

    [HttpGet]
    [Route("name/{name}")]
    [ProducesOk]
    [ProducesNotFound]
    public async Task<ActionResult<GetProductView>> GetProductByName(string name)
    {
        GetProductDto productDto = await ProductService.GetProductByName(new NotNullString(name));
        GetProductView getProductView = GetProductView.FromGetProductDto(productDto);
        return Ok(getProductView);
    }
}