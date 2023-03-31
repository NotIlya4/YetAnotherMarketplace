using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Services.ProductService;

namespace Infrastructure.Repositories.ProductRepository;

public interface IProductsRepository
{
    public Task<Product> GetProduct(ProductStrictFilter productStrictFilter);
    public Task<List<Product>> GetProducts(GetProductsQuery query);
    public Task<int> GetProductsCountForFilters(ProductFluentFilters fluentFilters);
    public Task Insert(Product product);
    public Task Delete(Product product);
}