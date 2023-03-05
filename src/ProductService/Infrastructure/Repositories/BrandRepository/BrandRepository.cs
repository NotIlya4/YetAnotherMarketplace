using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Extensions;
using Infrastructure.Repositories.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BrandRepository;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BrandRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Brand> GetBrandByIdAsync(Guid brandId)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Id.Equals(brandId));
    }

    public async Task<Brand> GetBrandByNameAsync(NotNullString brandName)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Name.Equals(brandName));
    }

    public async Task<List<Brand>> GetBrandsAsync(Pagination pagination)
    {
        return await _dbContext.Brands
            .ApplyPagination(pagination)
            .ToListAsync();
    }

    public async Task InsertAsync(Brand brand)
    {
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
    }
}