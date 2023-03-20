using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.ProductTypeService;

public interface IProductTypeService
{
    public Task<List<ProductType>> GetProductTypes();
    public Task<ProductType> Add(Name productTypeName);
    public Task Delete(Name productType);
}