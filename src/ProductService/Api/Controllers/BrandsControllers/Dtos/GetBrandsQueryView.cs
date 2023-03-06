using Infrastructure.ListQuery;

namespace Api.Controllers.BrandsControllers.Dtos;

public class GetBrandsQueryView
{
    public required int Offset { get; set; }
    public required int Limit { get; set; }
    public required string SortingType { get; set; }

    public Pagination ToPagination()
    {
        return new Pagination(
            offset: Offset,
            limit: Limit);
    }

    public SortingType ToSortingType()
    {
        return SortingTypeParser.ParseSortingType(SortingType);
    }
}