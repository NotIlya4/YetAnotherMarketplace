using Domain.Entities.Brand;
using Infrastructure.Data.EntityFramework;
using Infrastructure.Data.Repositories.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.BrandRepository;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BrandRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Brand> GetBrandById(BrandId brandId)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Id == brandId);
    }

    public async Task<Brand> GetBrandByName(string brandName)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Name == brandName);
    }

    public async Task<List<Brand>> GetBrands()
    {
        return await _dbContext.Brands.ToListAsync();
    }

    public async Task Insert(Brand brand)
    {
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
    }
}