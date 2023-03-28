using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.SortingSystem;

namespace UnitTests.Infrastructure.SortingSystem;

public class ProductSortingInfo_ConstructorTests
{
    [Fact]
    public void EmptyList_PrimarySortingDefaultValue()
    {
        SortingInfo<Product> defaultSortingInfo = new(nameof(Product.Name), SortingSide.Asc);
        ProductSortingInfo productSortingInfo = new(new List<SortingInfo<Product>>());

        var sortingInfo = productSortingInfo.PrimarySorting;
        
        Assert.Equal(defaultSortingInfo, sortingInfo);
    }

    [Fact]
    public void ThreeSortingInfos_PrimarySortingInfoMustBeFirstAndRestIsSecondSortingInfos()
    {
        SortingInfo<Product> first = new(nameof(Product.Name), SortingSide.Asc);
        SortingInfo<Product> second = new(nameof(Product.Name), SortingSide.Desc);
        SortingInfo<Product> third = new(nameof(Product.Name), SortingSide.Desc);
        ProductSortingInfo productSortingInfo = new ProductSortingInfo(new List<SortingInfo<Product>>() {first, second, third});
        
        Assert.Equal(first, productSortingInfo.PrimarySorting);
        Assert.Equal(second, productSortingInfo.SecondarySortings[0]);
        Assert.Equal(third, productSortingInfo.SecondarySortings[1]);
    }

    [Fact]
    public void UnavailableSortingInfo_ThrowException()
    {
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo<Product>(nameof(Product.Id), SortingSide.Asc)));
        new ProductSortingInfo(new SortingInfo<Product>(nameof(Product.Name), SortingSide.Asc));
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo<Product>(nameof(Product.Description), SortingSide.Asc)));
        new ProductSortingInfo(new SortingInfo<Product>(nameof(Product.Price), SortingSide.Asc));
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo<Product>(nameof(Product.PictureUrl), SortingSide.Asc)));
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo<Product>(nameof(Product.ProductType), SortingSide.Asc)));
        Assert.Throws<ValidationException>(() =>
            new ProductSortingInfo(new SortingInfo<Product>(nameof(Product.Brand), SortingSide.Asc)));
    }
}