using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Repositories.ProductTypeRepository;

public interface IProductTypesRepository
{
    public Task<List<ProductType>> GetProductTypes();
    public Task<ProductType> GetProductType(Name name);
    public Task Insert(ProductType productType);
    public Task Delete(ProductType productType);
}