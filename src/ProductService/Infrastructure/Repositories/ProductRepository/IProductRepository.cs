using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;

namespace Infrastructure.Repositories.ProductRepository;

public interface IProductRepository
{
    public Task<Product> GetProduct(ProductStrictFilter productStrictFilter);
    public Task<List<Product>> GetProducts(GetProductsQuery query);
    public Task<int> GetProductsCountForFilters(ProductFluentFilters fluentFilters);
    public Task Insert(Product product);
    public Task Delete(ProductStrictFilter productStrictFilter);
}