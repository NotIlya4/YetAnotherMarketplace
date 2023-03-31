using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests;

[Collection(nameof(AppFixture))]
public class BrandsControllerTests : IDisposable
{
    public JArray InitialDbBrands { get; }
    public BrandsClient BrandsClient { get; }

    public BrandsControllerTests(AppFixture appFixture)
    {
        BrandsClient = new BrandsClient(appFixture.Client);
        
        InitialDbBrands = new JArray()
        {
            new JObject()
            {
                ["id"] = "2d15e347-cf3d-4d8c-bdd7-c65f22e653f4",
                ["name"] = "Apple"
            },
            new JObject()
            {
                ["id"] = "aa7fe749-2e4b-45c4-b3f7-49c6f30d7d10",
                ["name"] = "McDonald's"
            }
        };
    }

    [Fact]
    public async Task GetBrands_ReturnBrands()
    {
        JArray result = await BrandsClient.GetBrands();

        Assert.Equal(InitialDbBrands, result);

        await AssertBrandsDefault();
    }

    [Fact]
    public async Task AddBrand_ReturnPersistedBrand()
    {
        string newBrand = "Barbie";

        JObject postBrandResponse = await BrandsClient.PostNewBrand(newBrand);
        Assert.Equal(newBrand, postBrandResponse.String("name"));

        List<JToken> expectBrandsInDb = new JArray(InitialDbBrands).ToList();
        expectBrandsInDb.Insert(1, postBrandResponse);
        
        List<JToken> brandsInDb = (await BrandsClient.GetBrands()).ToList();
        Assert.Equal(expectBrandsInDb, brandsInDb);

        await BrandsClient.DeleteBrand(newBrand);
        
        await AssertBrandsDefault();
    }

    [Fact]
    public async Task DeleteBrand_DeleteBrand()
    {
        string newBrand = "Puma";
        string? newBrandId = (await BrandsClient.PostNewBrand(newBrand)).String("id");
        
        List<JToken> expectBrandsAfterPost = new JArray(InitialDbBrands).ToList();
        expectBrandsAfterPost.Add(new JObject() {["id"] = newBrandId, ["name"] = newBrand});

        List<JToken> brandsAfterPost = (await BrandsClient.GetBrands()).ToList();
        Assert.Equal(expectBrandsAfterPost, brandsAfterPost);

        await BrandsClient.DeleteBrand(newBrand);
        
        List<JToken> brandsAfterDelete = (await BrandsClient.GetBrands()).ToList();
        
        Assert.Equal(InitialDbBrands, brandsAfterDelete);
        
        await AssertBrandsDefault();
    }

    public void Dispose()
    {
        
    }

    private async Task AssertBrandsDefault()
    {
        JArray brands = await BrandsClient.GetBrands();
        Assert.Equal(InitialDbBrands, brands);
    }
}