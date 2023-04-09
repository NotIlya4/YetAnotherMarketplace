using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public static class ProductQueryableExtensions
{
    public static IQueryable<ProductData> IncludeProductDependencies(this IQueryable<ProductData> dbSet)
    {
        return dbSet
            .Include(p => p.Brand)
            .Include(p => p.ProductType);
    }

    public static async Task<ProductData> GetProduct(this ApplicationDbContext dbContext, ProductStrictFilter strictFilter)
    {
        return await dbContext.Products.IncludeProductDependencies().FirstAsyncOrThrow(strictFilter);
    }

    public static async Task SetProduct(this ApplicationDbContext dbContext, ProductData productData)
    {
        ProductData? dbProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == productData.Id);
        if (dbProduct is null)
        {
            dbContext.SetEntry(productData.ProductType);
            dbContext.SetEntry(productData.Brand);
            
            await dbContext.Products.AddAsync(productData);
            await dbContext.SaveChangesAsync();
        }
    }

    public static async Task SetProducts(this ApplicationDbContext dbContext, IEnumerable<ProductData> productDatas)
    {
        foreach (var productData in productDatas)
        {
            await dbContext.SetProduct(productData);
        }
    }
}