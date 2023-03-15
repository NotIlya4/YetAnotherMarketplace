using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    public Task<Product> GetProductById(Guid productId);
    public Task<Product> GetProductByName(Name productName);
    public Task<List<Product>> GetProducts(Pagination pagination, ProductSortingInfo productSortingInfo);
    public Task<Product> CreateNewProduct(CreateProductCommand createProductCommand);
    public Task DeleteProductById(Guid productId);
    public Task DeleteProductByName(Name productName);
}