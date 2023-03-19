using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.Extensions;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly SortingApplier _sortingApplier;

    public ProductRepository(ApplicationDbContext dbContext, SortingApplier sortingApplier)
    {
        _dbContext = dbContext;
        _sortingApplier = sortingApplier;
    }

    public async Task<Product> GetProductById(Guid productId)
    {
        return await _dbContext
            .Products
            .IncludeProductDependencies()
            .FirstAsyncOrThrow(p => p.Id.Equals(productId));
    }

    public async Task<Product> GetProductByName(Name name)
    {
        return await _dbContext
            .Products
            .IncludeProductDependencies()
            .FirstAsyncOrThrow(p => p.Name.Equals(name));
    }

    public async Task<List<Product>> GetProducts(Pagination pagination, ProductSortingInfo productSortingInfo)
    {
        IQueryable<Product> query = _dbContext
            .Products
            .IncludeProductDependencies();

        IQueryable<Product> sortedQuery = _sortingApplier.ApplySorting(query, productSortingInfo.PrimarySorting,
            productSortingInfo.SecondarySortings);
        
        return await sortedQuery
            .ApplyPagination(pagination)
            .ToListAsync();
    }

    public async Task Insert(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}