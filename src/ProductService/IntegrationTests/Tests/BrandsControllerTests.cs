using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests;

[Collection(nameof(AppFixture))]
public class BrandsControllerTests
{
    public JArray InitialDb { get; }
    public BrandsClient Client { get; }
    public AppFixture AppFixture { get; }
    public BrandsList BrandsList { get; }

    public BrandsControllerTests(AppFixture appFixture)
    {
        Client = new BrandsClient(appFixture.Client);
        InitialDb = appFixture.BrandsList.BrandsJArray;
        AppFixture = appFixture;
        BrandsList = AppFixture.BrandsList;
    }

    [Fact]
    public async Task GetBrands_ReturnBrands()
    {
        JArray result = await Client.GetBrands();

        Assert.Equal(InitialDb, result);
    }

    [Fact]
    public async Task AddBrand_ReturnPersistedBrand()
    {
        string newBrand = "Barbie";

        await Client.Add(newBrand);

        List<JToken> expectBrandsInDb = new JArray(InitialDb).ToList();
        expectBrandsInDb.Insert(1, newBrand);
        
        List<JToken> brandsInDb = (await Client.GetBrands()).ToList();
        Assert.Equal(expectBrandsInDb, brandsInDb);

        await AppFixture.ReloadDb();
    }

    [Fact]
    public async Task DeleteBrand_DeleteBrand()
    {
        await Client.Add("Sony");
        await Client.Delete("Sony");
        JArray brandsAfterDelete = await Client.GetBrands();
        
        Assert.Equal(InitialDb, brandsAfterDelete);

        await AppFixture.ReloadDb();
    }
}