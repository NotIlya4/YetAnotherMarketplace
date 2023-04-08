using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests.GetProductsControllerTests;

[Collection(nameof(AppFixture))]
public class GetProductsController_FluentFiltersTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
    public ProductsList ProductsList { get; }
    
    public GetProductsController_FluentFiltersTests(AppFixture appFixture)
    {
        Client = new ProductsClient(appFixture.Client);
        InitialDb = appFixture.ProductsList.ProductsJArray;
        ProductsList = appFixture.ProductsList;
    }
    
    [Fact]
    public async Task GetProducts_PassSearch_ProductsWithContainedSearch()
    {
        JArray expect = new()
        {
            ProductsList.IPhone13JObject,
            ProductsList.IPhone13ProMaxJObject,
        };
        
        JArray products = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, Searching = "iPhone" });

        Assert.Equal(expect, products);
    }

    [Fact]
    public async Task GetProducts_PassBrand_ProductsWithSpecifiedBrand()
    {
        JArray expect = new()
        {
            ProductsList.IBurgerJObject,
            ProductsList.IPhone13JObject,
            ProductsList.IPhone13ProMaxJObject,
        };
        
        JArray products = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, Brand = "Apple"});

        Assert.Equal(expect, products);
    }
    
    [Fact]
    public async Task GetProducts_PassProductType_ProductsWithSpecifiedProductType()
    {
        JArray expect = new()
        {
            ProductsList.BigMacJObject,
            ProductsList.IBurgerJObject,
            ProductsList.QuarterPounderJObject,
        };

        JArray products = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, ProductType = "Burger"});

        Assert.Equal(expect, products);
    }

    [Fact]
    public async Task GetProducts_PassProductTypeWithBrand_ProductsWithOverlapOfProductTypeAndBrand()
    {
        JArray expect = new()
        {
            ProductsList.IBurgerJObject,
        };

        JArray products = await Client.GetProducts(new GetProductsQueryView()
            { Offset = 0, Limit = 50, ProductType = "Burger", Brand = "Apple" });

        Assert.Equal(expect, products);
    }
    
    [Fact]
    public async Task GetProducts_Limit1_FirstProduct()
    {
        JArray expect = new()
        {
            ProductsList.BigMacJObject
        };

        JArray products = await Client.GetProducts(new GetProductsQueryView()
            { Offset = 0, Limit = 1});

        Assert.Equal(expect, products);
    }
    
    [Fact]
    public async Task GetProducts_Limit1Offset1_SecondProduct()
    {
        JArray expect = new()
        {
            ProductsList.IBurgerJObject
        };

        JArray products = await Client.GetProducts(new GetProductsQueryView()
            { Offset = 1, Limit = 1});

        Assert.Equal(expect, products);
    }
    
    [Fact]
    public async Task GetProducts_Limit1Offset1WithOtherFilters_SecondProductWithFilters()
    {
        JArray expect = new()
        {
            ProductsList.IPhone13ProMaxJObject
        };

        JArray products = await Client.GetProducts(new GetProductsQueryView()
            { Offset = 1, Limit = 1, Brand = "Apple", Searching = "iPhone" });

        Assert.Equal(expect, products);
    }
}