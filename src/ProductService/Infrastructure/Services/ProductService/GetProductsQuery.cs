using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.ProductService;

public class GetProductsQuery
{
    public required Pagination Pagination { get; init; }
    public required ProductSortingInfo ProductSortingInfo { get; init; }
    public Name? ProductTypeName { get; init; }
    public Name? BrandName { get; init; }
}