using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;

namespace Infrastructure.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductService(IProductRepository productRepository, IBrandRepository brandRepository,
        IProductTypeRepository productTypeRepository)
    {
        _productRepository = productRepository;
        _brandRepository = brandRepository;
        _productTypeRepository = productTypeRepository;
    }

    public async Task<Product> GetProductByName(Name productName)
    {
        return await _productRepository.GetProductByName(productName);
    }

    public async Task<Product> CreateNewProduct(CreateProductCommand createProductCommand)
    {
        ProductType productType = await _productTypeRepository.GetProductTypeByName(createProductCommand.ProductTypeName);
        Brand brand = await _brandRepository.GetBrandByName(createProductCommand.BrandName);

        Product product = createProductCommand.ToDomain(Guid.NewGuid(), brand, productType);

        await _productRepository.Insert(product);

        return product;
    }

    public async Task<List<Product>> GetProducts(GetProductsQuery query)
    {
        return await _productRepository.GetProducts(query);
    }

    public async Task DeleteProductByName(Name productName)
    {
        Product product = await _productRepository.GetProductByName(productName);
        await _productRepository.Delete(product);
    }
}