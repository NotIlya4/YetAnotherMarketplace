namespace Api.Controllers.ProductsControllers.Views;

public record GetProductsResultView
{
    public required List<ProductView> Products { get; set; }
    public required int Total { get; set; }
}