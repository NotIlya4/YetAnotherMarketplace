using Domain.Entities;
using Infrastructure.SortingSystem.Core;

namespace Infrastructure.SortingSystem;

public class BrandSortingInfo : ISortingInfoProvider<Brand>
{
    public IPropertySortingInfoProvider<Brand> PrimarySorting { get; }
    public IEnumerable<IPropertySortingInfoProvider<Brand>> SecondarySortings { get; }

    private static readonly AvailablePropertiesValidator<Brand> AvailablePropertiesValidator = new(
        new List<string>() 
        { 
            nameof(Brand.Name) 
        });

    public BrandSortingInfo(List<PropertySortingInfo<Brand>> sortingInfos)
    {
        AvailablePropertiesValidator.Validate(sortingInfos);
        
        PrimarySorting = sortingInfos.Count == 0
            ? new PropertySortingInfo<Brand>(nameof(Brand.Name), SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).Select(s => (IPropertySortingInfoProvider<Brand>)s).ToList();
    }
}