using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
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
        ProductData productData = await _dbContext
            .Products
            .IncludeProductDependencies()
            .FirstAsyncOrThrow(p => p.Id.Equals(productId.ToString()));
        return productData.ToDomain();
    }

    public async Task<Product> GetProductByName(Name name)
    {
        ProductData productData = await _dbContext
            .Products
            .IncludeProductDependencies()
            .FirstAsyncOrThrow(p => p.Name.Equals(name));
        return productData.ToDomain();
    }

    public async Task<List<Product>> GetProducts(GetProductsQuery getProductsQuery)
    {
        IQueryable<ProductData> query = _dbContext
            .Products
            .IncludeProductDependencies();

        ProductDataSortingInfo sortingInfo = ProductDataSortingInfo.FromDomain(getProductsQuery.SortingInfo);
        IQueryable<ProductData> sortedQuery =
            _sortingApplier.ApplySorting(query, sortingInfo.PrimarySorting, sortingInfo.SecondarySortings);

        sortedQuery = ApplyFiltering(sortedQuery, getProductsQuery.FilteringInfo);

        List<ProductData> productDatas = await sortedQuery
            .ApplyPagination(getProductsQuery.Pagination)
            .ToListAsync();
        return ProductData.ToDomain(productDatas);
    }

    public async Task<int> GetProductsCount(ProductFilteringInfo filteringInfo)
    {
        IQueryable<ProductData> query = _dbContext
            .Products
            .IncludeProductDependencies();

        query = ApplyFiltering(query, filteringInfo);

        return await query.CountAsync();
    }

    private IQueryable<ProductData> ApplyFiltering(IQueryable<ProductData> query, ProductFilteringInfo filteringInfo)
    {
        if (filteringInfo.ProductTypeName is not null)
        {
            query = query.Where(p => p.ProductType.Name.Equals(filteringInfo.ProductTypeName.Value.Value));
        }
        
        if (filteringInfo.BrandName is not null)
        {
            query = query.Where(p => p.Brand.Name.Equals(filteringInfo.BrandName.Value.Value));
        }

        if (filteringInfo.Searching is not null)
        {
            query = query.Where(p => p.Name.Contains(filteringInfo.Searching.Value.Value));
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