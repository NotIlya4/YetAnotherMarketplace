using Api.Controllers.Attributes;
using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.Services.ProductService;
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
    public async Task<ActionResult<GetProductsResultView>> GetProducts([FromQuery] GetProductsQueryView queryView)
    {
        GetProductsQuery query = new()
        {
            Pagination = new Pagination(offset: queryView.Offset, limit: queryView.Limit),
            ProductSortingInfo = new ProductSortingInfo(_sortingInfoParser.Parse<Product>(queryView.Sortings)),
            BrandName = queryView.BrandName is null ? null : new Name(queryView.BrandName),
            ProductTypeName = queryView.ProductTypeName is null ? null : new Name(queryView.ProductTypeName)
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
    [Route("name/{name}", Name = nameof(GetProductByName))]
    [ProducesOk]
    [ProducesProductNotFound]
    public async Task<ActionResult<ProductView>> GetProductByName(string name)
    {
        Product productDto = await ProductService.GetProductByName(new Name(name));
        ProductView productView = ProductView.FromProduct(productDto);
        return Ok(productView);
    }
}