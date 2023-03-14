using Api.Swagger.Enrichers.Brand;
using Infrastructure.FilteringSystem;

namespace Api.Controllers.BrandsControllers.Views;

public class GetBrandsQueryView
{
    public required int Offset { get; init; }
    public required int Limit { get; init; }
    [BrandSorting]
    public required IEnumerable<string> Sorting { get; init; }

    public Pagination ToPagination()
    {
        return new Pagination(Offset, Limit);
    }
}