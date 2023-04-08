using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;

namespace Infrastructure.Repositories.BrandRepository;

public static class BrandQueryableExtensions
{
    public static async Task<BrandData> GetBrand(this ApplicationDbContext dbContext, Name brand)
    {
        return await dbContext.Brands.FirstAsyncOrThrow(b => b.Name == brand.Value);
    }
}