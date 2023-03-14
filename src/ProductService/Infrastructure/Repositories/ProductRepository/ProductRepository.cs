using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.Extensions;
using Infrastructure.SortingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly SortingApplier<Product> _sortingApplier;

    public ProductRepository(ApplicationDbContext dbContext, SortingApplier<Product> sortingApplier)
    {
        _dbContext = dbContext;
        _sortingApplier = sortingApplier;
    }

    public async Task<Product> GetProductById(Guid productId)
    {
        return await _dbContext
            .Products
            .IncludeProductDependencies()
            .FirstAsyncOrThrow<ProductRepository, Product>(p => p.Id.Equals(productId));
    }

    public async Task<Product> GetProductByName(NotNullString name)
    {
        return await _dbContext
            .Products
            .IncludeProductDependencies()
            .FirstAsyncOrThrow<ProductRepository, Product>(p => p.Name.Equals(name));
    }

    public async Task<List<Product>> GetProducts(Pagination pagination, ISortingInfoProvider<Product> sortingInfoProvider)
    {
        IQueryable<Product> query = _dbContext
            .Products
            .IncludeProductDependencies();
        
        IQueryable<Product> sortedQuery = _sortingApplier.ApplySorting(query, sortingInfoProvider);
        
        return await sortedQuery
            .ApplyPagination(pagination)
            .ToListAsync();
    }

    public async Task Insert(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }
}