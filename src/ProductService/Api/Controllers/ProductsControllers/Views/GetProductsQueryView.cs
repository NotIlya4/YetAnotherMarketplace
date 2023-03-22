using Api.Swagger.Enrichers.GetProductsQueryView;

namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsQueryView
{
    public required int Offset { get; set; }
    public required int Limit { get; set; }
    [ProductSortings]
    public IEnumerable<string>? Sortings { get; set; }
    [GetProductsProductTypeName]
    public string? ProductTypeName { get; set; }
    [GetProductsBrandName]
    public string? BrandName { get; set; }

    public string? Searching { get; set; }
}