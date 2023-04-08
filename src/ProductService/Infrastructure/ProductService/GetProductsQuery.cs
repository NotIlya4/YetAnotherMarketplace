using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.SortingSystem.Product;

namespace Infrastructure.ProductService;

public record GetProductsQuery
{
    public required Pagination Pagination { get; init; }
    public required ProductSortingCollection SortingCollection { get; init; }
    public required ProductFluentFilters FluentFilters { get; init; }
}