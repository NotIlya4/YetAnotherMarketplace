using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Repositories.ProductTypeRepository;

namespace Infrastructure.Services.ProductTypeService;

public class ProductTypeService : IProductTypeService
{
    private readonly IProductTypesRepository _productTypesRepository;

    public ProductTypeService(IProductTypesRepository productTypesRepository)
    {
        _productTypesRepository = productTypesRepository;
    }
    
    public async Task<List<ProductType>> GetProductTypes()
    {
        return await _productTypesRepository.GetProductTypes();
    }

    public async Task<ProductType> Add(Name productTypeName)
    {
        ProductType productType = new(Guid.NewGuid(), productTypeName);
        await _productTypesRepository.Insert(productType);
        return productType;
    }

    public async Task Delete(Name productType)
    {
        ProductType productTypeToDelete = await _productTypesRepository.GetProductType(productType);
        await _productTypesRepository.Delete(productTypeToDelete);
    }
}