using Api.Swagger.Enrichers.Product;
using Infrastructure.FilteringSystem;

namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsQueryView
{
    public required int Offset { get; init; }
    public required int Limit { get; init; }
    [ProductSorting]
    public required IEnumerable<string>? Sorting { get; init; }

    public Pagination ToPagination()
    {
        return new Pagination(Offset, Limit);
    }
}