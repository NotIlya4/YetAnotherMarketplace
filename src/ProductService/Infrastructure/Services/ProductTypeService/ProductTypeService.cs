using Domain.Entities;
using Domain.Primitives;
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

    public async Task<ProductType> Add(Name productTypeName)
    {
        ProductType productType = new(Guid.NewGuid(), productTypeName);
        await _productTypeRepository.Insert(productType);
        return productType;
    }

    public async Task Delete(Name productType)
    {
        ProductType productTypeToDelete = await _productTypeRepository.GetProductTypeByName(productType);
        await _productTypeRepository.Delete(productTypeToDelete);
    }
}