using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;

namespace Infrastructure.Repositories.ProductTypeRepository;

public static class ProductTypeQueryableExtensions
{
    public static async Task<ProductTypeData> GetProductType(this ApplicationDbContext dbContext, Name productType)
    {
        return await dbContext.ProductTypes.FirstAsyncOrThrow(p => p.Name == productType.Value);
    }
}