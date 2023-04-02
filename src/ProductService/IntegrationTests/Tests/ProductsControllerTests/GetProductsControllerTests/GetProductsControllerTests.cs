using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests.GetProductsControllerTests;

[Collection(nameof(AppFixture))]
public class GetProductsControllerTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
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
        JObject response = await Client.GetProductsBase(new GetProductsQueryView() { Offset = 0, Limit = 50 });
        JArray responseProducts = response["products"]?.Value<JArray>()!;
        int total = response["total"]!.Value<int>()!;
        
        Assert.Equal(InitialDb, responseProducts);
        Assert.Equal(5, total);
    }
}