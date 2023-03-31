using Api.Extensions;
using Infrastructure.EntityFramework;
using IntegrationTests.Fixtures.EntityLists;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Fixtures;

[CollectionDefinition(nameof(AppFixture))]
public class AppFixture : ICollectionFixture<AppFixture>, IDisposable
{
    public HttpClient Client { get; }
    private WebApplicationFactory<Program> WebApplicationFactory { get; }

    public AppFixture()
    {
        BrandsList brandsList = new();
        ProductTypesList productTypesList = new();
        ProductsList productsList = new(brandsList, productTypesList);

        WebApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("IntegrationTests");
        });
        Client = WebApplicationFactory.CreateClient();
        
        ApplicationDbContext dbContext = WebApplicationFactory.Services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureDeleted();
        WebApplicationFactory.Services.ApplyMigrations();
        
        DbSeeder seeder = new(brandsList.BrandDatas, productTypesList.ProductTypeDatas, productsList.ProductDatas);
        seeder.Seed(dbContext);
    }

    public void Dispose()
    {
        ApplicationDbContext dbContext = WebApplicationFactory.Services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureDeleted();
    }
}