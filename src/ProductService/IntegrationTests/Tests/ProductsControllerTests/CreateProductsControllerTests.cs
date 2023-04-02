using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests;

[Collection(nameof(AppFixture))]
public class CreateProductsControllerTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
    public AppFixture AppFixture { get; }
    
    public CreateProductsControllerTests(AppFixture appFixture)
    {
        InitialDb = appFixture.ProductsList.ProductsJArray;
        Client = new ProductsClient(appFixture.Client);
        AppFixture = appFixture;
    }

    [Fact]
    public async Task CreateProduct_ReturnPersistedProduct()
    {
        JObject newProduct = new JObject()
        {
            ["name"] = "Samsung Galaxy S21",
            ["description"] =
                "The Samsung Galaxy S21 is a high-end smartphone with a 6.2-inch display and a triple-lens rear camera system.",
            ["price"] = 999.99m,
            ["pictureUrl"] = "https://example.com/product.jpg",
            ["productType"] = "Smartphone",
            ["brand"] = "Apple"
        };
        JObject responsePostProduct = await Client.CreateProduct(newProduct);
        newProduct["id"] = responsePostProduct.String("id");
        
        Assert.True(JToken.DeepEquals(newProduct, responsePostProduct));

        JArray expectProducts = new JArray(InitialDb);
        expectProducts.Add(responsePostProduct);

        JArray products = await Client.GetProducts(new() { Limit = 50, Offset = 0 });
        
        Assert.Equal(expectProducts, products);

        await Client.DeleteProduct("id", newProduct.String("id"));

        await AppFixture.ReloadDb();
    }
}