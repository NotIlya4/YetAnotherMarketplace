using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.ListQuery;
using Infrastructure.Repositories.Extensions;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BrandRepository;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly QueryableSorterApplier _queryableSorterApplier;

    public BrandRepository(ApplicationDbContext dbContext, QueryableSorterApplier queryableSorterApplier)
    {
        _dbContext = dbContext;
        _queryableSorterApplier = queryableSorterApplier;
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
        
        IQueryable<Brand> sortedQuery = _queryableSorterApplier
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