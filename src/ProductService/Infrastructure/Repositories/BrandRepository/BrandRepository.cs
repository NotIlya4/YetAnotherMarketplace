using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.ListQuery;
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

    public async Task<Brand> GetBrandById(Guid brandId)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Id.Equals(brandId));
    }

    public async Task<Brand> GetBrandByName(NotNullString brandName)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Name.Equals(brandName));
    }

    public async Task<List<Brand>> GetBrands(Pagination pagination, SortingType sortingType)
    {
        return await _dbContext.Brands
            .ApplySorting(b => b.Name, sortingType)
            .ApplyPagination(pagination)
            .ToListAsync();
    }

    public async Task Insert(Brand brand)
    {
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
    }
}