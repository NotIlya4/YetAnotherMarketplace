using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    public Task<List<Product>> GetProducts(Pagination pagination, ProductSortingInfo productSortingInfo);
    public Task<Product> GetProductByName(Name productName);
    public Task<Product> CreateNewProduct(CreateProductCommand createProductCommand);
    public Task DeleteProductByName(Name productName);
}