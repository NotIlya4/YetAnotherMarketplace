using Domain.Entities.Product;

namespace Infrastructure.Data.Repositories.ProductRepository;

public interface IProductRepository
{
    public Task<Product> GetProductByIdAsync(ProductId id);
    public Task<Product> GetProductByNameAsync(string name);
    public Task<List<Product>> GetProductsAsync();
    public Task InsertAsync(Product product);
}