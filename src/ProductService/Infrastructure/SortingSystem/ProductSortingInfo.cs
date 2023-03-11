using Domain.Entities;
using Infrastructure.SortingSystem.Core;

namespace Infrastructure.SortingSystem;

public class ProductSortingInfo : ISortingInfoProvider<Product>
{
    public SortingInfo<Product> PrimarySorting { get; }

    public IEnumerable<SortingInfo<Product>> SecondarySortings { get; }
    
    private static readonly AvailablePropertiesValidator<Product> AvailablePropertiesValidator = new(
        new List<string>()
        {
            nameof(Product.Name),
            nameof(Product.Price)
        });

    public ProductSortingInfo(List<SortingInfo<Product>> sortingInfos)
    {
        AvailablePropertiesValidator.Validate(sortingInfos);

        PrimarySorting = sortingInfos.Count == 0
            ? new SortingInfo<Product>(nameof(Product.Name), SortingSide.Asc)
            : sortingInfos[0];
        SecondarySortings = sortingInfos.Skip(1).ToList();
    }
}