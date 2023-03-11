using Infrastructure.ListQuery;

namespace Api.Controllers.BrandsControllers.Dtos;

public class GetBrandsQueryView
{
    public required PaginationView Pagination { get; init; }
    public required IEnumerable<string> Sorting { get; init; }

    public Pagination ToPagination()
    {
        return Pagination.ToPagination();
    }
}