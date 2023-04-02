using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests.GetProductsControllerTests;

[Collection(nameof(AppFixture))]
public class GetProductsController_StrictFiltersTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
    public AppFixture AppFixture { get; }
    
    public GetProductsController_StrictFiltersTests(AppFixture appFixture)
    {
        Client = new ProductsClient(appFixture.Client);
        InitialDb = appFixture.ProductsList.ProductsJArray;
        AppFixture = appFixture;
    }

    [Fact]
    public async Task GetProduct_ById_ProductWithSpecifiedId()
    {
        JObject product = await Client.GetProduct("id", AppFixture.ProductsList.IBurger.Id.ToString());
        
        Assert.Equal(AppFixture.ProductsList.IBurgerJObject, product);
    }
    
    [Fact]
    public async Task GetProduct_ByName_ProductWithSpecifiedName()
    {
        JObject product = await Client.GetProduct("name", AppFixture.ProductsList.IPhone13.Name.ToString());
        
        Assert.Equal(AppFixture.ProductsList.IPhone13JObject, product);
    }
}