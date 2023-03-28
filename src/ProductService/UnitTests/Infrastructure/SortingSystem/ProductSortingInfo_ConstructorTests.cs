using Domain.Entities;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Product;

namespace UnitTests.Infrastructure.SortingSystem;

public class ProductSortingInfo_ConstructorTests
{
    [Fact]
    public void EmptyList_PrimarySortingDefaultValue()
    {
        ProductSorting defaultSorting = new(ProductSortingProperty.Name, SortingSide.Asc);
        ProductSortingCollection productSortingCollection = new(new List<ProductSorting>());

        ProductSorting sorting = productSortingCollection.PrimarySorting;
        
        Assert.Equal(defaultSorting, sorting);
    }

    [Fact]
    public void ThreeSortingInfos_PrimarySortingInfoMustBeFirstAndRestIsSecondSortingInfos()
    {
        ProductSorting first = new(nameof(Product.Name), SortingSide.Asc);
        ProductSorting second = new(nameof(Product.Name), SortingSide.Desc);
        ProductSorting third = new(nameof(Product.Name), SortingSide.Desc);
        ProductSortingCollection productSortingCollection = new(new List<ProductSorting>() {first, second, third});
        
        Assert.Equal(first, productSortingCollection.PrimarySorting);
        Assert.Equal(second, productSortingCollection.SecondarySortings[0]);
        Assert.Equal(third, productSortingCollection.SecondarySortings[1]);
    }
}