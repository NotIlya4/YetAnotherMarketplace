using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Extensions;
using Infrastructure.Repositories.ProductTypeRepository;
using Infrastructure.SortingSystem;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private DataMapper Mapper { get; }
    private ApplicationDbContext DbContext { get; }

    public ProductRepository(ApplicationDbContext dbContext, DataMapper mapper)
    {
        Mapper = mapper;
        DbContext = dbContext;
    }

    public async Task<Product> GetProduct(ProductStrictFilter productStrictFilter)
    {
        ProductData productData = await DbContext.GetProduct(productStrictFilter);
        return Mapper.MapProduct(productData);
    }

    public async Task<List<Product>> GetProducts(GetProductsQuery getProductsQuery)
    {
        IQueryable<ProductData> query = DbContext
            .Products
            .IncludeProductDependencies();

        IQueryable<ProductData> sortedQuery = query.ApplySorting(getProductsQuery.SortingCollection.PrimarySorting,
            getProductsQuery.SortingCollection.SecondarySortings.Select(s => (ISorting)s).ToList());

        sortedQuery = ApplyFiltering(sortedQuery, getProductsQuery.FluentFilters);

        List<ProductData> productDatas = await sortedQuery
            .ApplyPagination(getProductsQuery.Pagination)
            .ToListAsync();
        return Mapper.MapProduct(productDatas);
    }

    public async Task<int> GetProductsCountForFilters(ProductFluentFilters fluentFilters)
    {
        IQueryable<ProductData> query = DbContext
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
        BrandData brandData = await DbContext.GetBrand(product.Brand);
        ProductTypeData productTypeData = await DbContext.GetProductType(product.ProductType);
        
        ProductData productData = Mapper.MapProduct(product, productTypeData, brandData);

        SetProductEntry(productData);

        await DbContext.Products.AddAsync(productData);
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(ProductStrictFilter productStrictFilter)
    {
        ProductData productData = await DbContext.GetProduct(productStrictFilter);
        
        SetProductEntry(productData);
        
        DbContext.Products.Remove(productData);
        await DbContext.SaveChangesAsync();
    }

    private void SetProductEntry(ProductData productData)
    {
        DbContext.SetEntry(productData);
        DbContext.SetEntry(productData.Brand);
        DbContext.SetEntry(productData.ProductType);
    }
}