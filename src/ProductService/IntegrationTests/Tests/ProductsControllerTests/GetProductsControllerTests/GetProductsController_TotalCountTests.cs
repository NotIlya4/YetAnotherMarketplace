using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.ProductsControllerTests.GetProductsControllerTests;

[Collection(nameof(AppFixture))]
public class GetProductsController_TotalCountTests
{
    public ProductsClient Client { get; }
    public JArray InitialDb { get; }
    public AppFixture AppFixture { get; }
    
    public GetProductsController_TotalCountTests(AppFixture appFixture)
    {
        Client = new ProductsClient(appFixture.Client);
        InitialDb = appFixture.ProductsList.ProductsJArray;
        AppFixture = appFixture;
    }

    [Fact]
    public async Task GetProducts_Limit1Offset1_CountRegardlessLimitAndOffset()
    {
        int total = await Client.GetProductsTotal(new GetProductsQueryView() { Offset = 1, Limit = 1 });
        
        Assert.Equal(5, total);
    }

    [Fact]
    public async Task GetProducts_Filters_CountWithAppliedFilters()
    {
        int total = await Client.GetProductsTotal(new GetProductsQueryView() { Offset = 0, Limit = 50, BrandName = "Apple"});
        
        Assert.Equal(3, total);
    }
    
    [Fact]
    public async Task GetProducts_Limit1Offset1WithFilters_CountWithAppliedFiltersRegardlessLimitAndOffset()
    {
        int total = await Client.GetProductsTotal(new GetProductsQueryView() { Offset = 1, Limit = 1, BrandName = "Apple"});
        
        Assert.Equal(3, total);
    }
}