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
    private readonly SortingApplier<Brand> _sortingApplier;

    public BrandRepository(ApplicationDbContext dbContext, SortingApplier<Brand> sortingApplier)
    {
        _dbContext = dbContext;
        _sortingApplier = sortingApplier;
    }

    public async Task<Brand> GetBrandById(Guid brandId)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Id.Equals(brandId));
    }

    public async Task<Brand> GetBrandByName(NotNullString brandName)
    {
        return await _dbContext.Brands.FirstAsyncOrThrow<BrandRepository, Brand>(b => b.Name.Equals(brandName));
    }

    public async Task<List<Brand>> GetBrands(Pagination pagination, ISortingInfoProvider<Brand> sortingInfoProvider)
    {
        IQueryable<Brand> query = _dbContext
            .Brands;
        
        IQueryable<Brand> sortedQuery = _sortingApplier
            .ApplySorting(query, sortingInfoProvider);
        
        return await sortedQuery
            .ApplyPagination(pagination)
            .ToListAsync();
    }

    public async Task Insert(Brand brand)
    {
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
    }
}