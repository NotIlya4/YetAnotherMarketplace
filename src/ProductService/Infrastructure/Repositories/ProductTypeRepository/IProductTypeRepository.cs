using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Repositories.ProductTypeRepository;

public interface IProductTypeRepository
{
    public Task<List<ProductType>> GetProductTypes();
    public Task<ProductType> GetProductTypeByName(Name productType);
}