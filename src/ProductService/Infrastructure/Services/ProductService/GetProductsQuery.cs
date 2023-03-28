using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Product;

namespace Infrastructure.Services.ProductService;

public class GetProductsQuery
{
    public required Pagination Pagination { get; set; }
    public required ProductSortingInfoCollection SortingInfoCollection { get; set; }
    public required ProductFilteringInfo FilteringInfo { get; set; }
}