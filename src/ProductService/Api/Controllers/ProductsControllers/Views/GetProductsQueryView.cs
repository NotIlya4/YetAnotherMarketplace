using Api.Swagger.Enrichers.GetProductsQueryView;

namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsQueryView
{
    public required int Offset { get; init; }
    public required int Limit { get; init; }
    [ProductSortings]
    public IEnumerable<string>? Sortings { get; init; }
    [GetProductsProductTypeName]
    public string? ProductTypeName { get; init; }
    [GetProductsBrandName]
    public string? BrandName { get; init; }
}