using Api.Controllers.ProductsControllers.Dtos;
using Api.ControllersAttributes;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Services.ProductService;
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
    public async Task<ActionResult<List<ProductView>>> GetProducts([FromQuery] GetProductsQueryView getProductsQueryView)
    {
        List<Product> products = await ProductService.GetProducts(
            pagination: getProductsQueryView.ToPagination(),
            sortingField: getProductsQueryView.ToSortingField(),
            sortingType: getProductsQueryView.ToSortingType());
        List<ProductView> productViews = products.Select(ProductView.FromGetProductDto).ToList();
        return Ok(productViews);
    }

    [HttpGet]
    [Route("id/{id}", Name = nameof(GetProductById))]
    [ProducesOk]
    [ProducesNotFound]
    public async Task<ActionResult<ProductView>> GetProductById(Guid id)
    {
        Product product = await ProductService.GetProductById(id);
        ProductView productView = ProductView.FromGetProductDto(product);
        return Ok(productView);
    }

    [HttpGet]
    [Route("name/{name}")]
    [ProducesOk]
    [ProducesNotFound]
    public async Task<ActionResult<ProductView>> GetProductByName(string name)
    {
        Product productDto = await ProductService.GetProductByName(new NotNullString(name));
        ProductView productView = ProductView.FromGetProductDto(productDto);
        return Ok(productView);
    }
}