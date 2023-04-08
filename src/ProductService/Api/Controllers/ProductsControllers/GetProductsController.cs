using Api.Controllers.ProductsControllers.Helpers;
using Api.Controllers.ProductsControllers.Views;
using Api.ProducesAttributes;
using Api.SwaggerEnrichers.ProductStrictFilterView;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Infrastructure.SortingSystem.Product;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
public class GetProductsController : ProductsControllerBase
{
    private IProductService ProductService { get; }
    private ViewMapper Mapper { get; }
    private SortingInfoParser SortingInfoParser { get; }

    public GetProductsController(IProductService productService, ViewMapper mapper, SortingInfoParser sortingInfoParser)
    {
        ProductService = productService;
        Mapper = mapper;
        SortingInfoParser = sortingInfoParser;
    }

    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<GetProductsResultView>> GetProducts([FromQuery] GetProductsQueryView queryView)
    {
        GetProductsQuery query = new()
        {
            Pagination = new Pagination(offset: queryView.Offset, limit: queryView.Limit),
            SortingCollection = 
                new ProductSortingCollection(SortingInfoParser.ParseProductSortingInfo(queryView.Sortings ?? new List<string>())),
            FluentFilters = new ProductFluentFilters(
                productTypeName: queryView.ProductType is null ? null : new Name(queryView.ProductType),
                brandName: queryView.Brand is null ? null : new Name(queryView.Brand),
                searching: queryView.Searching is null ? null : new Name(queryView.Searching))
        };

        GetProductsResult result = await ProductService.GetProducts(query);
        List<ProductView> productViews = Mapper.MapProduct(result.Products);
        
        return Ok(new GetProductsResultView()
        {
            Products = productViews,
            Total = result.Total
        });
    }

    [HttpGet]
    [Route("{propertyName}/{value}")]
    [ProducesOk]
    [ProducesEntityNotFound]
    public async Task<ActionResult<ProductView>> GetProduct([ProductStrictFilterPropertyName] string propertyName, string value)
    {
        Product product = await ProductService.GetProduct(new ProductStrictFilter(
            productPropertyName: propertyName, 
            expectedValue: value));
        ProductView productView = Mapper.MapProduct(product);
        return Ok(productView);
    }
}