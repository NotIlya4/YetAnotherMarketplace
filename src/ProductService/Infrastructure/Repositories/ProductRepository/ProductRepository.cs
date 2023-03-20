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

        if (getProductsQuery.ProductTypeName is not null)
        {
            sortedQuery = sortedQuery.Where(p => p.ProductType.Name.Equals(getProductsQuery.ProductTypeName));
        }
        
        if (getProductsQuery.BrandName is not null)
        {
            sortedQuery = sortedQuery.Where(p => p.Brand.Name.Equals(getProductsQuery.BrandName));
        }
        
        return await sortedQuery
            .ApplyPagination(getProductsQuery.Pagination)
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