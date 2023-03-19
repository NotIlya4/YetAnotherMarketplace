using Domain.Entities;
using Infrastructure.Repositories.ProductTypeRepository;

namespace Infrastructure.Services.ProductTypeService;

public class ProductTypeService : IProductTypeService
{
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductTypeService(IProductTypeRepository productTypeRepository)
    {
        _productTypeRepository = productTypeRepository;
    }
    
    public async Task<List<ProductType>> GetProductTypes()
    {
        return await _productTypeRepository.GetAll();
    }
}