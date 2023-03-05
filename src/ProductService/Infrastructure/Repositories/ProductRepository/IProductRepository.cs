using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Repositories.Primitives;

namespace Infrastructure.Repositories.ProductRepository;

public interface IProductRepository
{
    public Task<Product> GetProductByIdAsync(Guid productId);
    public Task<Product> GetProductByNameAsync(NotNullString productName);
    public Task<List<Product>> GetProductsAsync(Pagination pagination);
    public Task InsertAsync(Product product);
}