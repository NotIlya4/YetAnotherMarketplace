using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.ProductService;

public class GetProductsQuery
{
    public required Pagination Pagination { get; set; }
    public required ProductSortingInfo SortingInfo { get; set; }
    public required ProductFilteringInfo FilteringInfo { get; set; }
}