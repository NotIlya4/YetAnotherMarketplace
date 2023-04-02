using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests;

[Collection(nameof(AppFixture))]
public class TempTests
{
    public AppFixture AppFixture { get; }
    
    public TempTests(AppFixture appFixture)
    {
        AppFixture = appFixture;
    }
    
    public async Task Test()
    {
        var client = new ProductsClient(AppFixture.Client);

        JArray responseProducts = await client.GetProducts(new GetProductsQueryView() { Limit = 50, Offset = 0 });
        
        Assert.Equal(AppFixture.ProductsList.BigMacJObject, responseProducts[0]);
        Assert.Equal(AppFixture.ProductsList.IPhone13JObject, responseProducts[1]);
        Assert.Equal(AppFixture.ProductsList.IPhone13ProMaxJObject, responseProducts[2]);
        Assert.Equal(AppFixture.ProductsList.QuerterPounderJObject, responseProducts[3]);
        
        Assert.Equal(AppFixture.ProductsList.ProductsJArray, responseProducts);
    }
}