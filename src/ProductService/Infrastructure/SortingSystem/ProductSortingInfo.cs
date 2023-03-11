using Domain.Entities;
using Infrastructure.SortingSystem.Core;

namespace Infrastructure.SortingSystem;

public class ProductSortingInfo : ISortingInfoProvider<Product>
{
    public IPropertySortingInfoProvider<Product> PrimarySorting { get; }

    public IEnumerable<IPropertySortingInfoProvider<Product>> SecondarySortings { get; }
    
    private static readonly AvailablePropertiesValidator<Product> AvailablePropertiesValidator = new(
        new List<string>()
        {
            nameof(Product.Name),
            nameof(Product.Price)
        });

    public ProductSortingInfo(List<PropertySortingInfo<Product>> sortingInfos)
    {
        AvailablePropertiesValidator.Validate(sortingInfos);

        PrimarySorting = sortingInfos.Count == 0
            ? new PropertySortingInfo<Product>(nameof(Product.Name), SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).Select(s => (IPropertySortingInfoProvider<Product>)s).ToList();
    }
}