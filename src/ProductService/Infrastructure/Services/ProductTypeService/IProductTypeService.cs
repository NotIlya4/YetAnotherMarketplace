using Domain.Entities;

namespace Infrastructure.Services.ProductTypeService;

public interface IProductTypeService
{
    public Task<List<ProductType>> GetProductTypes();
}