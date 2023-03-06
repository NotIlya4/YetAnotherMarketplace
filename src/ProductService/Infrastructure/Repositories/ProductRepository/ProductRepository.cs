using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.ListQuery;
using Infrastructure.Repositories.Extensions;
using Infrastructure.Services.ProductService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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

    public async Task<List<Product>> GetProducts(Pagination pagination, ProductSortingField sortingField, SortingType sortingType)
    {
        return await _dbContext
            .Products
            .IncludeProductDependencies()
            .ApplySorting(sortingField.ProductProperty, sortingType)
            .ApplyPagination(pagination)
            .ToListAsync();
    }

    public async Task Insert(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }
}