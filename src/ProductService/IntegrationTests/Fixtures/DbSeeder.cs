using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;

namespace IntegrationTests.Fixtures;

public class DbSeeder
{
    public IEnumerable<BrandData> BrandDatas { get; }
    public IEnumerable<ProductTypeData> ProductTypeDatas { get; }
    public IEnumerable<ProductData> ProductDatas { get; }

    public DbSeeder(IEnumerable<BrandData> brandsList, IEnumerable<ProductTypeData> productTypeDatas, IEnumerable<ProductData> productDatas)
    {
        BrandDatas = brandsList;
        ProductTypeDatas = productTypeDatas;
        ProductDatas = productDatas;
    }

    public void Seed(ApplicationDbContext dbContext)
    {
        SeedBrands(dbContext, BrandDatas);
        SeedProductTypes(dbContext, ProductTypeDatas);
        SeedProducts(dbContext, ProductDatas);
    }

    private void SeedBrands(ApplicationDbContext dbContext, IEnumerable<BrandData> brandDatas)
    {
        dbContext.Brands.AddRange(brandDatas);
        dbContext.SaveChanges();
        dbContext.ChangeTracker.Clear();
    }

    private void SeedProductTypes(ApplicationDbContext dbContext, IEnumerable<ProductTypeData> productTypeDatas)
    {
        dbContext.ProductTypes.AddRange(productTypeDatas);
        dbContext.SaveChanges();
        dbContext.ChangeTracker.Clear();
    }

    private void SeedProducts(ApplicationDbContext dbContext, IEnumerable<ProductData> productDatas)
    {
        productDatas = productDatas.ToList();
        foreach (var productData in productDatas)
        {
            BrandData brandData = dbContext.Brands.First(b => b.Id == productData.Brand.Id);
            ProductTypeData productTypeData = dbContext.ProductTypes.First(pt => pt.Id == productData.ProductType.Id);
        
            productData.Brand = brandData;
            productData.ProductType = productTypeData;
        }

        dbContext.Products.AddRange(productDatas);
        dbContext.SaveChanges();
        dbContext.ChangeTracker.Clear();
    }
}