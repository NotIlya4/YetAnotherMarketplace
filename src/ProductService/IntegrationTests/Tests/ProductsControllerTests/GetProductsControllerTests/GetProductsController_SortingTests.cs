using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests.GetProductsControllerTests;

[Collection(nameof(AppFixture))]
public class GetProductsController_SortingTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
    public AppFixture AppFixture { get; }
    
    public GetProductsController_SortingTests(AppFixture appFixture)
    {
        Client = new ProductsClient(appFixture.Client);
        InitialDb = appFixture.ProductsList.ProductsJArray;
        AppFixture = appFixture;
    }
    
    [Fact]
    public async Task GetProducts_NameDescSorting_SortedProducts()
    {
        JArray expect = new()
        {
            AppFixture.ProductsList.QuarterPounderJObject,
            AppFixture.ProductsList.IPhone13ProMaxJObject,
            AppFixture.ProductsList.IPhone13JObject,
            AppFixture.ProductsList.IBurgerJObject,
            AppFixture.ProductsList.BigMacJObject,
        };
        
        JArray products = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, Sortings = new []{"-name"}});

        Assert.Equal(expect, products);
    }

    [Fact]
    public async Task GetProducts_PriceAscSorting_SortedProducts()
    {
        JArray expect = new()
        {
            AppFixture.ProductsList.BigMacJObject,
            AppFixture.ProductsList.QuarterPounderJObject,
            AppFixture.ProductsList.IBurgerJObject,
            AppFixture.ProductsList.IPhone13JObject,
            AppFixture.ProductsList.IPhone13ProMaxJObject,
        };
        
        JArray products = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, Sortings = new []{"+price"}});

        Assert.Equal(expect, products);
    }
    
    [Fact]
    public async Task GetProducts_PriceDescSorting_SortedProducts()
    {
        JArray expect = new()
        {
            AppFixture.ProductsList.IPhone13ProMaxJObject,
            AppFixture.ProductsList.IPhone13JObject,
            AppFixture.ProductsList.IBurgerJObject,
            AppFixture.ProductsList.QuarterPounderJObject,
            AppFixture.ProductsList.BigMacJObject,
        };
        
        JArray products = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, Sortings = new []{"-price"}});

        Assert.Equal(expect, products);
    }
}