using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.SortingSystem.Product;

namespace Infrastructure.Services.ProductService;

public class GetProductsQuery
{
    public required Pagination Pagination { get; set; }
    public required ProductSortingCollection SortingCollection { get; set; }
    public required ProductFluentFilters FluentFilters { get; set; }
}