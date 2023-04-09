using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Seeder;
using Infrastructure.Extensions;
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
    private readonly DbSeeder _seeder;
    private readonly DbMigrator _migrator;

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

        var scope = WebApplicationFactory.Services.CreateScope();
        ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureDeleted();

        _migrator = new DbMigrator(WebApplicationFactory.Services);
        _migrator.Migrate().GetAwaiter().GetResult();

        _seeder = new DbSeeder(WebApplicationFactory.Services, BrandsList.BrandDatas, ProductTypesList.ProductTypeDatas,
            ProductsList.ProductDatas);
        _seeder.Seed().GetAwaiter().GetResult();
    }

    public async Task ReloadDb()
    {
        await WebApplicationFactory.Services.UsingScope<ApplicationDbContext>(async dbContext =>
        {
            await dbContext.Database.EnsureDeletedAsync();
        });

        await _migrator.Migrate();
        await _seeder.Seed();
    }

    public void Dispose()
    {
        ApplicationDbContext dbContext = WebApplicationFactory.Services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureDeleted();
    }
}