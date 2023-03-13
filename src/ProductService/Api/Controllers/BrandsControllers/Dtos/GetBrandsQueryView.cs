using Infrastructure.ListQuery;

namespace Api.Controllers.BrandsControllers.Dtos;

public class GetBrandsQueryView
{
    public required int Offset { get; init; }
    public required int Limit { get; init; }
    public required IEnumerable<string> Sorting { get; init; }

    public Pagination ToPagination()
    {
        return new Pagination(Offset, Limit);
    }
}