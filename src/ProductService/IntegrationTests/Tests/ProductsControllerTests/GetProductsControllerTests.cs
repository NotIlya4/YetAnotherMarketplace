using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests;

[Collection(nameof(AppFixture))]
public class GetProductsControllerTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
    public JFactory JFactory { get; } = new();
    public AppFixture AppFixture { get; }
    
    public GetProductsControllerTests(AppFixture appFixture)
    {
        Client = new ProductsClient(appFixture.Client);
        InitialDb = appFixture.ProductsList.ProductsJArray;
        AppFixture = appFixture;
    }

    [Fact]
    public async Task GetProducts_ReturnInitialDb()
    {
        JObject response = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50 });
        JArray responseProducts = response["products"]?.Value<JArray>()!;
        int total = response["total"]!.Value<int>()!;
        
        Assert.Equal(InitialDb, responseProducts);
        Assert.Equal(4, total);
    }

    [Fact]
    public async Task GetProducts_PassSearch_ProductsWithContainedSearch()
    {
        List<Product> expectProducts = new()
        {
            AppFixture.ProductsList.IPhone13,
            AppFixture.ProductsList.IPhone13ProMax,
        };
        JArray expectJArray = JFactory.Create(ProductView.FromDomain(expectProducts));
        
        JObject response = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, Searching = "iPhone" });
        JArray products = response["products"]?.Value<JArray>()!;
        
        Assert.Equal(expectJArray, products);
    }

    [Fact]
    public async Task GetProducts_PassBrand_ProductsWithSpecifiedBrand()
    {
        List<Product> expectProducts = new()
        {
            AppFixture.ProductsList.IPhone13,
            AppFixture.ProductsList.IPhone13ProMax,
        };
        JArray expectJArray = JFactory.Create(ProductView.FromDomain(expectProducts));
        
        JObject response = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, BrandName = "Apple"});
        JArray products = response["products"]?.Value<JArray>()!;
        
        Assert.Equal(expectJArray, products);
    }
    
    [Fact]
    public async Task GetProducts_PassProductType_ProductsWithSpecifiedProductType()
    {
        List<Product> expectProducts = new()
        {
            AppFixture.ProductsList.IPhone13,
            AppFixture.ProductsList.IPhone13ProMax,
        };
        JArray expectJArray = JFactory.Create(ProductView.FromDomain(expectProducts));
        
        JObject response = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, ProductTypeName = "Smartphone"});
        JArray products = response["products"]?.Value<JArray>()!;
        
        Assert.Equal(expectJArray, products);
    }
    
    [Fact]
    public async Task GetProducts_PassSorting_SortedProducts()
    {
        List<Product> expectProducts = new()
        {
            AppFixture.ProductsList.QuerterPounder,
            AppFixture.ProductsList.IPhone13ProMax,
            AppFixture.ProductsList.IPhone13,
            AppFixture.ProductsList.BigMac,
        };
        JArray expectJArray = JFactory.Create(ProductView.FromDomain(expectProducts));
        
        JObject response = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50, Sortings = new []{"-name"}});
        JArray products = response["products"]?.Value<JArray>()!;
        
        Assert.Equal(expectJArray, products);
    }
}