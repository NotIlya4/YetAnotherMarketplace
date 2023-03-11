using Infrastructure.ListQuery;

namespace Api.Controllers.ProductsControllers.Dtos;

public class GetProductsQueryView
{
    public required PaginationView PaginationView { get; init; }
    public required IEnumerable<string> Sorting { get; init; }

    public Pagination ToPagination()
    {
        return PaginationView.ToPagination();
    }
}