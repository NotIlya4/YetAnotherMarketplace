using Domain.Entities;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.SortingSystem.SortingInfoProviders;

public class ProductSortingInfo
{
    public ISortingInfo PrimarySorting { get; }
    public List<ISortingInfo> SecondarySortings { get; }
    public static List<string> AvailableSortingProperties { get; } = new()
        {
            nameof(Product.Name),
            nameof(Product.Price)
        };

    private static readonly AvailablePropertiesValidator AvailablePropertiesValidator =
        new(AvailableSortingProperties);

    public ProductSortingInfo(ISortingInfo sortingInfo) 
        : this(new List<ISortingInfo>() {sortingInfo})
    {
        
    }
    
    public ProductSortingInfo(List<ISortingInfo> sortingInfos)
    {
        AvailablePropertiesValidator.Validate(sortingInfos);

        PrimarySorting = sortingInfos.Count == 0
            ? new SortingInfo(nameof(Product.Name), SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).ToList();
    }
}