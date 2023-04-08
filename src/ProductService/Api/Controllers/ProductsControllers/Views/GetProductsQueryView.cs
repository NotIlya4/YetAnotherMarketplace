using Api.SwaggerEnrichers.GetProductsQueryView;

namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsQueryView
{
    public required int Offset { get; set; }
    public required int Limit { get; set; }
    [ProductSortings]
    public IEnumerable<string>? Sortings { get; set; }
    [GetProductsProductType]
    public string? ProductType { get; set; }
    [GetProductsBrand]
    public string? Brand { get; set; }
    [GetProductsSearching]
    public string? Searching { get; set; }
}