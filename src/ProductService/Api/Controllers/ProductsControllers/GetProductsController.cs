using Api.Controllers.Attributes;
using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Services.ProductService;
using Infrastructure.SortingSystem.Product;
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
    public async Task<ActionResult<GetProductsResultView>> GetProducts([FromQuery] GetProductsQueryView queryView)
    {
        GetProductsQuery query = new()
        {
            Pagination = new Pagination(offset: queryView.Offset, limit: queryView.Limit),
            SortingCollection = 
                new ProductSortingCollection(_sortingInfoParser.ParseProductSortingInfo(queryView.Sortings ?? new List<string>())),
            FluentFilters = new ProductFluentFilters(
                productTypeName: queryView.ProductTypeName is null ? null : new Name(queryView.ProductTypeName),
                brandName: queryView.BrandName is null ? null : new Name(queryView.BrandName),
                searching: queryView.Searching is null ? null : new Name(queryView.Searching))
        };

        GetProductsResult result = await ProductService.GetProducts(query);
        List<ProductView> productViews = ProductView.FromProducts(result.Products);
        
        return Ok(new GetProductsResultView()
        {
            Products = productViews,
            Total = result.Total
        });
    }

    [HttpGet]
    [Route("{propertyName}/{value}", Name = nameof(GetProduct))]
    [ProducesOk]
    [ProducesProductNotFound]
    public async Task<ActionResult<ProductView>> GetProduct(string propertyName, string value)
    {
        Product productDto = await ProductService.GetProduct(new ProductStrictFilter(propertyName, value));
        ProductView productView = ProductView.FromProduct(productDto);
        return Ok(productView);
    }
}