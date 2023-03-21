using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.ProductService;

public class GetProductsQuery
{
    public required Pagination Pagination { get; init; }
    public required ProductSortingInfo SortingInfo { get; init; }
    public required ProductFilteringInfo FilteringInfo { get; init; }
}