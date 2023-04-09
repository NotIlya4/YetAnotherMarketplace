using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BrandRepository;

public static class BrandQueryableExtensions
{
    public static async Task<BrandData> GetBrand(this ApplicationDbContext dbContext, Name brand)
    {
        return await dbContext.Brands.FirstAsyncOrThrow(b => b.Name == brand.Value);
    }

    public static async Task SetBrand(this ApplicationDbContext dbContext, BrandData brandData)
    {
        BrandData? dbBrand = await dbContext.Brands.FirstOrDefaultAsync(b => b.Id == brandData.Id);
        if (dbBrand is null)
        {
            await dbContext.Brands.AddAsync(brandData);
            await dbContext.SaveChangesAsync();
        }
    }

    public static async Task SetBrands(this ApplicationDbContext dbContext, IEnumerable<BrandData> brandDatas)
    {
        foreach (var brandData in brandDatas)
        {
            await dbContext.SetBrand(brandData);
        }
    }
}