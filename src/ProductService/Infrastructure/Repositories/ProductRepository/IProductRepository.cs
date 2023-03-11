using Domain.Entities;
using Domain.Primitives;
using Infrastructure.ListQuery;
using Infrastructure.SortingSystem.Core;

namespace Infrastructure.Repositories.ProductRepository;

public interface IProductRepository
{
    public Task<Product> GetProductById(Guid productId);
    public Task<Product> GetProductByName(NotNullString productName);
    public Task<List<Product>> GetProducts(Pagination pagination, ISortingInfoProvider<Product> sortingInfoProvider);
    public Task Insert(Product product);
}