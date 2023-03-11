using Api.Controllers.ProductsControllers.Dtos;
using Api.ControllersAttributes;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.ListQuery;
using Infrastructure.Services.ProductService;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

public class GetProductsController : ProductsControllerBase
{
    private readonly SortingInfoParser<Product> _sortingInfoParser;

    public GetProductsController(IProductService productService, SortingInfoParser<Product> sortingInfoParser) : base(productService)
    {
        _sortingInfoParser = sortingInfoParser;
    }

    [HttpGet]
    [ProducesOk]
    [ProducesBadRequest]
    public async Task<ActionResult<List<ProductView>>> GetProducts([FromQuery] GetProductsQueryView getProductsQueryView)
    {
        Pagination pagination = getProductsQueryView.ToPagination();

        List<SortingInfo<Product>> parsedPropertySortingInfos =
            _sortingInfoParser.Parse(getProductsQueryView.Sorting);
        ProductSortingInfo productSortingInfo = new(parsedPropertySortingInfos);

        List<Product> products = await ProductService.GetProducts(pagination, productSortingInfo);
        
        List<ProductView> productViews = ProductView.FromGetProductDto(products);
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