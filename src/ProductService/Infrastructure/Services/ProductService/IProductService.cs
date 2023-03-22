using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    public Task<GetProductsResult> GetProducts(GetProductsQuery query);
    public Task<Product> GetProductById(Guid id);
    public Task<Product> CreateNewProduct(CreateProductCommand createProductCommand);
    public Task DeleteProductById(Guid id);
}