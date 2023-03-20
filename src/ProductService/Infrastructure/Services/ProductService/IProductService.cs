using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    public Task<List<Product>> GetProducts(GetProductsQuery query);
    public Task<Product> GetProductByName(Name productName);
    public Task<Product> CreateNewProduct(CreateProductCommand createProductCommand);
    public Task DeleteProductByName(Name productName);
}