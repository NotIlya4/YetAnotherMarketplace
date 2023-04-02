using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests;

[Collection(nameof(AppFixture))]
public class ProductTypesControllerTests
{
    public JArray InitialDb { get; }
    public ProductTypesClient Client { get; }
    public AppFixture AppFixture { get; }
    public ProductTypesList ProductTypesList { get; }

    public ProductTypesControllerTests(AppFixture appFixture)
    {
        Client = new ProductTypesClient(appFixture.Client);
        InitialDb = appFixture.ProductTypesList.ProductTypesJArray;
        AppFixture = appFixture;
        ProductTypesList = AppFixture.ProductTypesList;
    }
    
    [Fact]
    public async Task GetProductTypes_ReturnProductTypes()
    {
        JArray result = await Client.GetProductTypes();

        Assert.Equal(InitialDb, result);
    }
    
    [Fact]
    public async Task AddProductType_ReturnPersistedProductType()
    {
        string newProductType = "Door";

        JObject postProductTypeResponse = await Client.PostNewProductType(newProductType);
        Assert.Equal(newProductType, postProductTypeResponse.String("name"));

        List<JToken> expectProductTypesInDb = new JArray(InitialDb).ToList();
        expectProductTypesInDb.Insert(1, postProductTypeResponse);
        
        List<JToken> productTypesInDb = (await Client.GetProductTypes()).ToList();
        Assert.Equal(expectProductTypesInDb, productTypesInDb);

        await AppFixture.ReloadDb();
    }
    
    [Fact]
    public async Task DeleteProductType_DeleteProductType()
    {
        await Client.PostNewProductType("Keyboard");
        await Client.DeleteProductType("Keyboard");
        JArray productTypesAfterDelete = await Client.GetProductTypes();
        
        Assert.Equal(InitialDb, productTypesAfterDelete);

        await AppFixture.ReloadDb();
    }
}