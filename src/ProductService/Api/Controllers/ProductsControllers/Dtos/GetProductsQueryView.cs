using Infrastructure.ListQuery;
using Infrastructure.Services.ProductService;

namespace Api.Controllers.ProductsControllers.Dtos;

public class GetProductsQueryView
{
    public required int Offset { get; set; }
    public required int Limit { get; set; }
    public required string SortingField { get; set; }
    public required string SortingType { get; set; }

    public Pagination ToPagination()
    {
        return new Pagination(
            offset: Offset, 
            limit: Limit);
    }

    public ProductSortingField ToSortingField()
    {
        return new ProductSortingField(SortingField);
    }

    public SortingType ToSortingType()
    {
        return SortingTypeParser.ParseSortingType(SortingType);
    }
}