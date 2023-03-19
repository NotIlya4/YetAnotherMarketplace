using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Repositories.ProductTypeRepository;

public interface IProductTypeRepository
{
    public Task<List<ProductType>> GetAll();
    public Task<ProductType> GetProductTypeByName(Name name);
    public Task Insert(ProductType productType);
    public Task Delete(ProductType productType);
}