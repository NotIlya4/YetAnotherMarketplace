using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.Extensions;
using Infrastructure.SortingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BrandRepository;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BrandRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Brand> GetBrandByName(Name brandName)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Name.Equals(brandName));
    }

    public async Task<List<Brand>> GetBrands()
    {
        return await _dbContext
            .Brands
            .ToListAsync();
    }

    public async Task Insert(Brand brand)
    {
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Brand brand)
    {
        _dbContext.Remove(brand);
        await _dbContext.SaveChangesAsync();
    }
}