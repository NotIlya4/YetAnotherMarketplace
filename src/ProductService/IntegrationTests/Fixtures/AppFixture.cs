using Api.Extensions;
using Infrastructure.EntityFramework;
using IntegrationTests.EntityLists;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Fixtures;

[CollectionDefinition(nameof(AppFixture))]
public class AppFixture : ICollectionFixture<AppFixture>, IDisposable
{
    public HttpClient Client { get; }
    internal WebApplicationFactory<Program> WebApplicationFactory { get; }
    public BrandsList BrandsList { get; }
    public ProductTypesList ProductTypesList { get; }
    public ProductsList ProductsList { get; }

    public AppFixture()
    {
        BrandsList = new BrandsList();
        ProductTypesList = new ProductTypesList();
        ProductsList = new ProductsList(BrandsList, ProductTypesList);

        WebApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("IntegrationTests");
        });
        Client = WebApplicationFactory.CreateClient();
        
        ApplicationDbContext dbContext = WebApplicationFactory.Services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureDeleted();
        WebApplicationFactory.Services.ApplyMigrations();
        
        DbSeeder seeder = new(BrandsList.BrandDatas, ProductTypesList.ProductTypeDatas, ProductsList.ProductDatas);
        seeder.Seed(dbContext);
    }

    public async Task ReloadDb()
    {
        ApplicationDbContext dbContext = WebApplicationFactory.Services.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.EnsureDeletedAsync();
        WebApplicationFactory.Services.ApplyMigrations();
        
        DbSeeder seeder = new(BrandsList.BrandDatas, ProductTypesList.ProductTypeDatas, ProductsList.ProductDatas);
        seeder.Seed(dbContext);
    }

    public void Dispose()
    {
        ApplicationDbContext dbContext = WebApplicationFactory.Services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureDeleted();
    }
}