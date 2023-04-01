using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests;

[Collection(nameof(AppFixture))]
public class DeleteProductsControllerTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
    public JFactory JFactory { get; } = new();
    public AppFixture AppFixture { get; }
    
    public DeleteProductsControllerTests(AppFixture appFixture)
    {
        Client = new ProductsClient(appFixture.Client);
        InitialDb = appFixture.ProductsList.ProductsJArray;
        AppFixture = appFixture;
    }
    
    [Fact]
    public async Task DeleteProduct_ByName_DeleteProduct()
    {
        List<Product> expectProducts = new()
        {
            AppFixture.ProductsList.BigMac,
            AppFixture.ProductsList.IPhone13ProMax,
            AppFixture.ProductsList.QuerterPounder,
        };
        JArray expectJArray = JFactory.Create(ProductView.FromDomain(expectProducts));
        
        await Client.DeleteProduct("name", AppFixture.ProductsList.IPhone13.Name.ToString());
        
        JObject response = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50 });
        JArray products = response["products"]?.Value<JArray>()!;
        
        Assert.Equal(expectJArray, products);

        JObject deletedProduct = JFactory.Create(ProductView.FromDomain(AppFixture.ProductsList.IPhone13));
        await Client.CreateProduct(deletedProduct);

        await AssertInitialDb();
    }
    
    public async Task AssertInitialDb()
    {
        JObject response = await Client.GetProducts(new() { Limit = 50, Offset = 0 });
        JArray products = response["products"]?.Value<JArray>()!;
        
        Assert.Equal(InitialDb, products);
    }
}