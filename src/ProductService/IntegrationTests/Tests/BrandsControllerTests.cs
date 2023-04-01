using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests;

[Collection(nameof(AppFixture))]
public class BrandsControllerTests
{
    public JArray InitialDb { get; }
    public BrandsClient Client { get; }

    public BrandsControllerTests(AppFixture appFixture)
    {
        Client = new BrandsClient(appFixture.Client);

        InitialDb = appFixture.BrandsList.BrandsJArray;
    }

    [Fact]
    public async Task GetBrands_ReturnBrands()
    {
        JArray result = await Client.GetBrands();

        Assert.Equal(InitialDb, result);

        await AssertBrandsDefault();
    }

    [Fact]
    public async Task AddBrand_ReturnPersistedBrand()
    {
        string newBrand = "Barbie";

        JObject postBrandResponse = await Client.PostNewBrand(newBrand);
        Assert.Equal(newBrand, postBrandResponse.String("name"));

        List<JToken> expectBrandsInDb = new JArray(InitialDb).ToList();
        expectBrandsInDb.Insert(1, postBrandResponse);
        
        List<JToken> brandsInDb = (await Client.GetBrands()).ToList();
        Assert.Equal(expectBrandsInDb, brandsInDb);

        await Client.DeleteBrand(newBrand);
        
        await AssertBrandsDefault();
    }

    [Fact]
    public async Task DeleteBrand_DeleteBrand()
    {
        string newBrand = "Puma";
        string? newBrandId = (await Client.PostNewBrand(newBrand)).String("id");
        
        List<JToken> expectBrandsAfterPost = new JArray(InitialDb).ToList();
        expectBrandsAfterPost.Add(new JObject() {["id"] = newBrandId, ["name"] = newBrand});

        List<JToken> brandsAfterPost = (await Client.GetBrands()).ToList();
        Assert.Equal(expectBrandsAfterPost, brandsAfterPost);

        await Client.DeleteBrand(newBrand);
        
        List<JToken> brandsAfterDelete = (await Client.GetBrands()).ToList();
        
        Assert.Equal(InitialDb, brandsAfterDelete);
        
        await AssertBrandsDefault();
    }

    private async Task AssertBrandsDefault()
    {
        JArray brands = await Client.GetBrands();
        Assert.Equal(InitialDb, brands);
    }
}