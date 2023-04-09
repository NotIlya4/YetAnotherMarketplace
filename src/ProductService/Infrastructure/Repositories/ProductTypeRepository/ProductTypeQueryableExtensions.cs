using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductTypeRepository;

public static class ProductTypeQueryableExtensions
{
    public static async Task<ProductTypeData> GetProductType(this ApplicationDbContext dbContext, Name productType)
    {
        return await dbContext.ProductTypes.FirstAsyncOrThrow(p => p.Name == productType.Value);
    }

    public static async Task SetProductType(this ApplicationDbContext dbContext, ProductTypeData productTypeData)
    {
        ProductTypeData? dbProductType = await dbContext.ProductTypes.FirstOrDefaultAsync(p => p.Id == productTypeData.Id);
        if (dbProductType is null)
        {
            await dbContext.ProductTypes.AddAsync(productTypeData);
            await dbContext.SaveChangesAsync();
        }
    }

    public static async Task SetProductTypes(this ApplicationDbContext dbContext, IEnumerable<ProductTypeData> productTypeDatas)
    {
        foreach (var productTypeData in productTypeDatas)
        {
            await SetProductType(dbContext, productTypeData);
        }
    }
}