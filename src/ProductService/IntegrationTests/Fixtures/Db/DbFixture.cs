using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Fixtures.Db;

public class DbFixture : IDisposable
{
    public ApplicationDbContext DbContext { get; }
    
    public DbFixture()
    {
        ApplicationDbContext dbContext = CreateDbContext();
        
        SeedBrands(dbContext);
        SeedProductTypes(dbContext);
        SeedProducts(dbContext);
        
        DbContext = CreateDbContext();
    }

    private void SeedBrands(ApplicationDbContext dbContext)
    {
        BrandsList brandsList = new();
        
        dbContext.Brands.AddRange(BrandData.FromDomain(brandsList.Brands));
        dbContext.SaveChanges();
    }
    
    private void SeedProductTypes(ApplicationDbContext dbContext)
    {
        ProductTypesList productTypesList = new();
        
        dbContext.ProductTypes.AddRange(ProductTypeData.FromDomain(productTypesList.ProductTypes));
        dbContext.SaveChanges();
    }
    
    private void SeedProducts(ApplicationDbContext dbContext)
    {
        ProductsList productsList = new(new BrandsList(), new ProductTypesList());
        List<ProductData> productDatas = ProductData.FromDomain(productsList.Products);

        foreach (var productData in productDatas)
        {
            BrandData brandData = dbContext.Brands.First(b => b.Id == productData.Brand.Id);
            ProductTypeData productTypeData = dbContext.ProductTypes.First(pt => pt.Id == productData.ProductType.Id);

            productData.Brand = brandData;
            productData.ProductType = productTypeData;
        }
        
        dbContext.Products.AddRange(productDatas);
        dbContext.SaveChanges();
    }

    private ApplicationDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Skinet").Options;
        return new ApplicationDbContext(options);
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }
}