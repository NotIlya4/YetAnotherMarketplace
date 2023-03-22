using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.Services.ProductService;

namespace Infrastructure.Repositories.ProductRepository;

public interface IProductRepository
{
    public Task<Product> GetProductById(Guid id);
    public Task<List<Product>> GetProducts(GetProductsQuery query);
    public Task<int> GetProductsCount(ProductFilteringInfo filteringInfo);
    public Task Insert(Product product);
    public Task Delete(Product product);
}