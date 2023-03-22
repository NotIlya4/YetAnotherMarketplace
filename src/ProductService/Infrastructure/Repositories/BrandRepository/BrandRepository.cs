using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BrandRepository;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BrandRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Brand>> GetAll()
    {
        List<BrandData> brandDatas = await _dbContext.Brands.ToListAsync();
        List<Brand> brands = brandDatas.Select(b => b.ToDomain()).ToList();
        return brands;
    }

    public async Task<Brand> GetBrandByName(Name name)
    {
        BrandData brandData = await _dbContext.Brands.FirstAsyncOrThrow(b => b.Name.Equals(name));
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