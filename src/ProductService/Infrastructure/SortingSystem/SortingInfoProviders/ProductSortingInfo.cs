using Domain.Entities;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.SortingSystem.SortingInfoProviders;

public class ProductSortingInfo : ISortingInfoProvider<Product>
{
    public SortingInfo<Product> PrimarySorting { get; }
    public List<SortingInfo<Product>> SecondarySortings { get; }
    public static List<string> AvailableSortingProperties { get; } = new()
        {
            nameof(Product.Name),
            nameof(Product.Price)
        };

    private static readonly AvailablePropertiesValidator<Product> AvailablePropertiesValidator =
        new(AvailableSortingProperties);

    public ProductSortingInfo(SortingInfo<Product> sortingInfo) 
        : this(new List<SortingInfo<Product>>() {sortingInfo})
    {
        
    }
    
    public ProductSortingInfo(List<SortingInfo<Product>> sortingInfos)
    {
        AvailablePropertiesValidator.Validate(sortingInfos);

        PrimarySorting = sortingInfos.Count == 0
            ? new SortingInfo<Product>(nameof(Product.Name), SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).ToList();
    }
}