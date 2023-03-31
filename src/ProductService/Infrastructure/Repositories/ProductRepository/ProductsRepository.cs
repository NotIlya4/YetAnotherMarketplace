using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Repositories.Extensions;
using Infrastructure.Services.ProductService;
using Infrastructure.SortingSystem;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetProduct(ProductStrictFilter productStrictFilter)
    {
        ProductData productData = await _dbContext
            .Products
            .AsNoTracking()
            .IncludeProductDependencies()
            .FirstAsyncOrThrow(productStrictFilter);
        return productData.ToDomain();
    }

    public async Task<List<Product>> GetProducts(GetProductsQuery getProductsQuery)
    {
        IQueryable<ProductData> query = _dbContext
            .Products
            .AsNoTracking()
            .IncludeProductDependencies();

        IQueryable<ProductData> sortedQuery = query.ApplySorting(getProductsQuery.SortingCollection.PrimarySorting,
            getProductsQuery.SortingCollection.SecondarySortings.Select(s => (ISorting)s).ToList());

        sortedQuery = ApplyFiltering(sortedQuery, getProductsQuery.FluentFilters);

        List<ProductData> productDatas = await sortedQuery
            .ApplyPagination(getProductsQuery.Pagination)
            .ToListAsync();
        return ProductData.ToDomain(productDatas);
    }

    public async Task<int> GetProductsCountForFilters(ProductFluentFilters fluentFilters)
    {
        IQueryable<ProductData> query = _dbContext
            .Products
            .AsNoTracking()
            .IncludeProductDependencies();

        query = ApplyFiltering(query, fluentFilters);

        return await query.CountAsync();
    }

    private IQueryable<ProductData> ApplyFiltering(IQueryable<ProductData> query, ProductFluentFilters fluentFilters)
    {
        if (fluentFilters.ProductTypeName is not null)
        {
            query = query.Where(p => p.ProductType.Name.Equals(fluentFilters.ProductTypeName.Value.Value));
        }
        
        if (fluentFilters.BrandName is not null)
        {
            query = query.Where(p => p.Brand.Name.Equals(fluentFilters.BrandName.Value.Value));
        }

        if (fluentFilters.Searching is not null)
        {
            query = query.Where(p => p.Name.Contains(fluentFilters.Searching.Value.Value));
        }

        return query;
    }

    public async Task Insert(Product product)
    {
        await _dbContext.Products.AddAsync(ProductData.FromDomain(product));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _dbContext.Products.Remove(ProductData.FromDomain(product));
        await _dbContext.SaveChangesAsync();
    }
}