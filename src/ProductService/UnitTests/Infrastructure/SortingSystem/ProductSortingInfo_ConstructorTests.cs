using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Product;

namespace UnitTests.Infrastructure.SortingSystem;

public class ProductSortingInfo_ConstructorTests
{
    [Fact]
    public void EmptyList_PrimarySortingDefaultValue()
    {
        ProductSortingInfo defaultSortingInfo = new(ProductSortingProperty.Name, SortingSide.Asc);
        ProductSortingInfoCollection productSortingInfoCollection = new(new List<ProductSortingInfo>());

        ProductSortingInfo sortingInfo = productSortingInfoCollection.PrimarySorting;
        
        Assert.Equal(defaultSortingInfo, sortingInfo);
    }

    [Fact]
    public void ThreeSortingInfos_PrimarySortingInfoMustBeFirstAndRestIsSecondSortingInfos()
    {
        ProductSortingInfo first = new(nameof(Product.Name), SortingSide.Asc);
        ProductSortingInfo second = new(nameof(Product.Name), SortingSide.Desc);
        ProductSortingInfo third = new(nameof(Product.Name), SortingSide.Desc);
        ProductSortingInfoCollection productSortingInfoCollection = new(new List<ProductSortingInfo>() {first, second, third});
        
        Assert.Equal(first, productSortingInfoCollection.PrimarySorting);
        Assert.Equal(second, productSortingInfoCollection.SecondarySortings[0]);
        Assert.Equal(third, productSortingInfoCollection.SecondarySortings[1]);
    }
}