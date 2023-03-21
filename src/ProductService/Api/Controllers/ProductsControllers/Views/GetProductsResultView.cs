namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsResultView
{
    public required List<ProductView> Products { get; set; }
    public required int Total { get; set; }
}