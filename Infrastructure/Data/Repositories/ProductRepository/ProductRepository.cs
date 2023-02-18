using Domain.Entities.Product;
using Infrastructure.Data.EntityFramework;
using Infrastructure.Data.Repositories.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetProductByIdAsync(ProductId id)
    {
        return await _dbContext
            .Products
            .Include(p => p.Brand)
            .FirstAsyncOrThrow<ProductRepository, Product>(p => p.Id == id);
    }

    public async Task<Product> GetProductByNameAsync(string name)
    {
        return await _dbContext
            .Products
            .Include(p => p.Brand)
            .FirstAsyncOrThrow<ProductRepository, Product>(p => p.Name == name);
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _dbContext
            .Products
            .Include(p => p.Brand)
            .ToListAsync();
    }

    public async Task InsertAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }
}