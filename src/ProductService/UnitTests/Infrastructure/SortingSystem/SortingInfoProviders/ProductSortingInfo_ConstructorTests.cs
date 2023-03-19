using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.SortingSystem.Models;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace UnitTests.Infrastructure.SortingSystem.SortingInfoProviders;

public class ProductSortingInfo_ConstructorTests
{
    [Fact]
    public void EmptyList_PrimarySortingDefaultValue()
    {
        SortingInfo defaultSortingInfoOld = new(nameof(Product.Name), SortingSide.Asc);
        ProductSortingInfo productSortingInfo = new(new List<ISortingInfo>());

        var sortingInfo = productSortingInfo.PrimarySorting;
        
        Assert.Equal(defaultSortingInfoOld, sortingInfo);
    }

    [Fact]
    public void ThreeSortingInfos_PrimarySortingInfoMustBeFirstAndRestIsSecondSortingInfos()
    {
        SortingInfo first = new(nameof(Product.Name), SortingSide.Asc);
        SortingInfo second = new(nameof(Product.Name), SortingSide.Desc);
        SortingInfo third = new(nameof(Product.Name), SortingSide.Desc);
        ProductSortingInfo productSortingInfo = new ProductSortingInfo(new List<ISortingInfo>() {first, second, third});
        
        Assert.Equal(first, productSortingInfo.PrimarySorting);
        Assert.Equal(second, productSortingInfo.SecondarySortings[0]);
        Assert.Equal(third, productSortingInfo.SecondarySortings[1]);
    }

    [Fact]
    public void UnavailableSortingInfo_ThrowException()
    {
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo(nameof(Product.Id), SortingSide.Asc)));
        new ProductSortingInfo(new SortingInfo(nameof(Product.Name), SortingSide.Asc));
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo(nameof(Product.Description), SortingSide.Asc)));
        new ProductSortingInfo(new SortingInfo(nameof(Product.Price), SortingSide.Asc));
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo(nameof(Product.PictureUrl), SortingSide.Asc)));
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo(nameof(Product.ProductType), SortingSide.Asc)));
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo(nameof(Product.Brand), SortingSide.Asc)));
    }
}