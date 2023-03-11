using Domain.Entities;
using Infrastructure.SortingSystem.Core;

namespace Infrastructure.SortingSystem;

public class BrandSortingInfoProvider : ISortingInfoProvider<Brand>
{
    public SortingInfo<Brand> PrimarySorting { get; }
    public IEnumerable<SortingInfo<Brand>> SecondarySortings { get; }

    private static readonly AvailablePropertiesValidator<Brand> AvailablePropertiesValidator = new(
        new List<string>() 
        { 
            nameof(Brand.Name) 
        });

    public BrandSortingInfoProvider(List<SortingInfo<Brand>> sortingInfos)
    {
        AvailablePropertiesValidator.Validate(sortingInfos);
        
        PrimarySorting = sortingInfos.Count == 0
            ? new SortingInfo<Brand>(nameof(Brand.Name), SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).ToList();
    }
}