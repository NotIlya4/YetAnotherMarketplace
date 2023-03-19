using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Repositories.ProductRepository;

public interface IProductRepository
{
    public Task<Product> GetProductById(Guid productId);
    public Task<Product> GetProductByName(Name productName);
    public Task<List<Product>> GetProducts(Pagination pagination, ProductSortingInfo productSortingInfo);
    public Task Insert(Product product);
    public Task Delete(Product product);
}