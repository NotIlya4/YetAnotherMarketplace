using Domain.Primitives;

namespace Infrastructure.Repositories.ProductTypeRepository;

public interface IProductTypeRepository
{
    public Task<List<Name>> GetProductTypes();
    public Task Add(Name productType);
    public Task Delete(Name productType);
}