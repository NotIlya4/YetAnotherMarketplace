using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests;

[Collection(nameof(AppFixture))]
public class DeleteProductsControllerTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
    public AppFixture AppFixture { get; }
    public ProductsList ProductsList { get; }
    
    public DeleteProductsControllerTests(AppFixture appFixture)
    {
        Client = new ProductsClient(appFixture.Client);
        InitialDb = appFixture.ProductsList.ProductsJArray;
        AppFixture = appFixture;
        ProductsList = appFixture.ProductsList;
    }
    
    [Fact]
    public async Task DeleteProduct_ByName_DeleteProduct()
    {
        JArray expect = new()
        {
            ProductsList.BigMacJObject,
            ProductsList.IBurgerJObject,
            ProductsList.IPhone13ProMaxJObject,
            ProductsList.QuerterPounderJObject,
        };

        await Client.DeleteProduct("name", AppFixture.ProductsList.IPhone13.Name.ToString());
        
        JArray products = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50 });
        
        Assert.Equal(expect, products);

        await AppFixture.ReloadDb();
    }
    
    [Fact]
    public async Task DeleteProduct_ById_DeleteProduct()
    {
        JArray expect = new()
        {
            ProductsList.BigMacJObject,
            ProductsList.IBurgerJObject,
            ProductsList.IPhone13JObject,
            ProductsList.IPhone13ProMaxJObject,
        };

        await Client.DeleteProduct("id", AppFixture.ProductsList.QuerterPounder.Id.ToString());
        
        JArray products = await Client.GetProducts(new GetProductsQueryView() { Offset = 0, Limit = 50 });
        
        Assert.Equal(expect, products);

        await AppFixture.ReloadDb();
    }
}