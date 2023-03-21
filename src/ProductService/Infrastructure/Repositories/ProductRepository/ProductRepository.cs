using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.Extensions;
using Infrastructure.Services.ProductService;
using Infrastructure.SortingSystem;
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

    public async Task<List<Product>> GetProducts(GetProductsQuery getProductsQuery)
    {
        IQueryable<Product> query = _dbContext
            .Products
            .IncludeProductDependencies();

        IQueryable<Product> sortedQuery = _sortingApplier.ApplySorting(query, getProductsQuery.SortingInfo.PrimarySorting,
            getProductsQuery.SortingInfo.SecondarySortings);

        sortedQuery = ApplyFiltering(sortedQuery, getProductsQuery.FilteringInfo);
        
        return await sortedQuery
            .ApplyPagination(getProductsQuery.Pagination)
            .ToListAsync();
    }

    public async Task<int> GetProductsCount(ProductFilteringInfo filteringInfo)
    {
        IQueryable<Product> query = _dbContext
            .Products
            .IncludeProductDependencies();

        query = ApplyFiltering(query, filteringInfo);

        return await query.CountAsync();
    }

    private IQueryable<Product> ApplyFiltering(IQueryable<Product> query, ProductFilteringInfo filteringInfo)
    {
        if (filteringInfo.ProductTypeName is not null)
        {
            query = query.Where(p => p.ProductType.Name.Equals(filteringInfo.ProductTypeName));
        }
        
        if (filteringInfo.BrandName is not null)
        {
            query = query.Where(p => p.Brand.Name.Equals(filteringInfo.BrandName));
        }

        return query;
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