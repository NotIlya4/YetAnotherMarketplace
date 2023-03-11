using Infrastructure.ListQuery;

namespace Api.Controllers;

public class PaginationView
{
    public required int Offset { get; init; }
    public required int Limit { get; init; }

    public Pagination ToPagination()
    {
        return new Pagination(Offset, Limit);
    }
}