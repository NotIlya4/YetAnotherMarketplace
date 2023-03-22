using Domain.Entities;
using Infrastructure.EntityFramework.Models;
using Infrastructure.SortingSystem.Models;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.EntityFramework;

public class ProductDataSortingInfo
{
    public required SortingInfo<ProductData> PrimarySorting { get; set; }
    public required List<SortingInfo<ProductData>> SecondarySortings { get; set; }

    public static ProductDataSortingInfo FromDomain(ProductSortingInfo productSortingInfo)
    {
        return new ProductDataSortingInfo()
        {
            PrimarySorting = ConvertSortingInfo(productSortingInfo.PrimarySorting),
            SecondarySortings = productSortingInfo.SecondarySortings.Select(ConvertSortingInfo).ToList()
        };
    }

    private static SortingInfo<ProductData> ConvertSortingInfo(SortingInfo<Product> sortingInfo)
    {
        return new SortingInfo<ProductData>(sortingInfo.PropertyName.Value, sortingInfo.SortingSide);
    }
}