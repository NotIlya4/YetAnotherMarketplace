using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
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
        return await _dbContext.Brands.ToListAsync();
    }

    public Task<Brand> GetBrandByName(Name name)
    {
        return _dbContext.Brands.FirstAsyncOrThrow(b => b.Name.Equals(name));
    }

    public async Task Insert(Brand brand)
    {
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Brand brand)
    {
        _dbContext.Brands.Remove(brand);
        await _dbContext.SaveChangesAsync();
    }
}