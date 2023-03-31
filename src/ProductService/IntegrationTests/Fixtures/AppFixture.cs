using Api.Extensions;
using Api.Properties;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using IntegrationTests.Fixtures.Db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Fixtures.App;

[CollectionDefinition(nameof(AppFixture))]
public class AppFixture : ICollectionFixture<AppFixture>, IDisposable
{
    public HttpClient Client { get; }
    public BrandsList BrandsList { get; }
    public ProductTypesList ProductTypesList { get; }
    public ProductsList ProductsList { get; }

    private WebApplicationFactory<Program> WebApplicationFactory { get; }

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

    public void Dispose()
    {
        ApplicationDbContext dbContext = WebApplicationFactory.Services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureDeleted();
    }
}