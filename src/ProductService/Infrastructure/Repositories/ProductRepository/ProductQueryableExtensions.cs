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
}