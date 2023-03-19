using Api.Controllers.Attributes;
using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.Services.ProductService;
using Infrastructure.SortingSystem.Models;
using Infrastructure.SortingSystem.SortingInfoProviders;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
public class GetProductsController : ProductsControllerBase
{
    private readonly SortingInfoParser _sortingInfoParser;

    public GetProductsController(IProductService productService, SortingInfoParser sortingInfoParser) : base(productService)
    {
        _sortingInfoParser = sortingInfoParser;
    }

    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<List<ProductView>>> GetProducts([FromQuery] GetProductsQueryView getProductsQueryView)
    {
        Pagination pagination = getProductsQueryView.ToPagination();

        List<ISortingInfo> parsedPropertySortingInfos =
            _sortingInfoParser.Parse(getProductsQueryView.Sorting);
        ProductSortingInfo productSortingInfo = new(parsedPropertySortingInfos);

        List<Product> products = await ProductService.GetProducts(pagination, productSortingInfo);
        
        List<ProductView> productViews = ProductView.FromProducts(products);
        return Ok(productViews);
    }

    [HttpGet]
    [Route("name/{name}")]
    [ProducesOk]
    [ProducesProductNotFound]
    public async Task<ActionResult<ProductView>> GetProductByName(string name)
    {
        Product productDto = await ProductService.GetProductByName(new Name(name));
        ProductView productView = ProductView.FromProduct(productDto);
        return Ok(productView);
    }
}