using Domain.Entities;
using Domain.Primitives;
using Infrastructure.ListQuery;
using Infrastructure.Services.ProductService;

namespace Infrastructure.Repositories.ProductRepository;

public interface IProductRepository
{
    public Task<Product> GetProductById(Guid productId);
    public Task<Product> GetProductByName(NotNullString productName);
    public Task<List<Product>> GetProducts(Pagination pagination, ProductSortingField sortingField, SortingType sortingType);
    public Task Insert(Product product);
}