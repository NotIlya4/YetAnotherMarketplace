using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Repositories.BrandRepository;

public class BrandsRepository : IBrandsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BrandsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Brand>> GetBrands()
    {
        List<BrandData> brandDatas = await _dbContext
            .Brands
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
        return brandDatas.Select(b => b.ToDomain()).ToList();
    }

    public async Task<Brand> GetBrand(Name name)
    {
        BrandData brandData = await _dbContext
            .Brands
            .AsNoTracking()
            .FirstAsyncOrThrow(b => b.Name == name.Value);
        return brandData.ToDomain();
    }

    public async Task Insert(Brand brand)
    {
        
        await _dbContext.Brands.AddAsync(BrandData.FromDomain(brand));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Brand brand)
    {
        _dbContext.Brands.Remove(BrandData.FromDomain(brand));
        await _dbContext.SaveChangesAsync();
    }
}