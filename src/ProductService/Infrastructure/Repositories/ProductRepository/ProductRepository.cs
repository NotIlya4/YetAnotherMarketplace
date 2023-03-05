using Domain.Entities;
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Extensions;
using Infrastructure.Repositories.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetProductByIdAsync(Guid productId)
    {
        return await _dbContext
            .Products
            .IncludeProductDependencies()
            .FirstAsyncOrThrow<ProductRepository, Product>(p => p.Id.Equals(productId));
    }

    public async Task<Product> GetProductByNameAsync(NotNullString name)
    {
        return await _dbContext
            .Products
            .IncludeProductDependencies()
            .FirstAsyncOrThrow<ProductRepository, Product>(p => p.Name.Equals(name));
    }

    public async Task<List<Product>> GetProductsAsync(Pagination pagination)
    {
        return await _dbContext
            .Products
            .IncludeProductDependencies()
            .ApplyPagination(pagination)
            .ToListAsync();
    }

    public async Task InsertAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }
}