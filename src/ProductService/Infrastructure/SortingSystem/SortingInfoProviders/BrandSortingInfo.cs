using Domain.Entities;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.SortingSystem.SortingInfoProviders;

public class BrandSortingInfo : ISortingInfoProvider<Brand>
{
    public SortingInfo<Brand> PrimarySorting { get; }
    public IEnumerable<SortingInfo<Brand>> SecondarySortings { get; }
    public static List<string> AvailableSortingProperties { get; } = new()
        {
            nameof(Brand.Name)
        };

    private static readonly AvailablePropertiesValidator<Brand> AvailablePropertiesValidator =
        new(AvailableSortingProperties);

    public BrandSortingInfo(List<SortingInfo<Brand>> sortingInfos)
    {
        AvailablePropertiesValidator.Validate(sortingInfos);
        
        PrimarySorting = sortingInfos.Count == 0
            ? new SortingInfo<Brand>(nameof(Brand.Name), SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).ToList();
    }
}