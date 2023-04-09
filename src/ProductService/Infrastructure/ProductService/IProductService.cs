using Domain.Entities;
using Infrastructure.FilteringSystem.Product;

namespace Infrastructure.ProductService;

public interface IProductService
{
    public Task<GetProductsResult> GetProducts(GetProductsQuery query);
    public Task<Product> GetProduct(ProductStrictFilter filter);
    public Task<Product> CreateNewProduct(CreateProductCommand createProductCommand);
    public Task DeleteProduct(ProductStrictFilter filter);
}