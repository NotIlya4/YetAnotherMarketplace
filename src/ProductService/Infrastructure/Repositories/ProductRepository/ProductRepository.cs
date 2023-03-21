using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
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

        IQueryable<Product> sortedQuery = _sortingApplier.ApplySorting(query, getProductsQuery.ProductSortingInfo.PrimarySorting,
            getProductsQuery.ProductSortingInfo.SecondarySortings);

        sortedQuery = ApplyFiltering(sortedQuery, getProductsQuery.ProductTypeName, getProductsQuery.BrandName);
        
        return await sortedQuery
            .ApplyPagination(getProductsQuery.Pagination)
            .ToListAsync();
    }

    public async Task<int> GetProductsCount(Name? productTypeName, Name? brandName)
    {
        IQueryable<Product> query = _dbContext
            .Products
            .IncludeProductDependencies();

        query = ApplyFiltering(query, productTypeName, brandName);

        return await query.CountAsync();
    }

    private IQueryable<Product> ApplyFiltering(IQueryable<Product> query, Name? productTypeName, Name? brandName)
    {
        if (productTypeName is not null)
        {
            query = query.Where(p => p.ProductType.Name.Equals(productTypeName));
        }
        
        if (brandName is not null)
        {
            query = query.Where(p => p.Brand.Name.Equals(brandName));
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