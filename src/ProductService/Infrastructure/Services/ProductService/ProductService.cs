using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;
using Infrastructure.SortingSystem.SortingInfoProviders;

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

    public async Task<Product> GetProductById(Guid productId)
    {
        return await _productRepository.GetProductById(productId);
    }

    public async Task<Product> GetProductByName(Name productName)
    {
        return await _productRepository.GetProductByName(productName);
    }

    public async Task<List<Product>> GetProducts(Pagination pagination, ProductSortingInfo productSortingInfo)
    {
        return await _productRepository.GetProducts(pagination, productSortingInfo);
    }

    public async Task<Product> CreateNewProduct(CreateProductCommand createProductCommand)
    {
        Brand brand = await _brandRepository.GetBrandByName(createProductCommand.BrandName);
        ProductType productType = await _productTypeRepository.GetProductTypeByName(createProductCommand.ProductType);
        
        Product product = createProductCommand.ToDomain(Guid.NewGuid(), brand, productType);
        await _productRepository.Insert(product);

        return product;
    }

    public async Task DeleteProductById(Guid productId)
    {
        Product product = await _productRepository.GetProductById(productId);
        await _productRepository.Delete(product);
    }

    public async Task DeleteProductByName(Name productName)
    {
        Product product = await _productRepository.GetProductByName(productName);
        await _productRepository.Delete(product);
    }
}