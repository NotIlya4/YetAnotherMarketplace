using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;

    public ProductService(IProductRepository productRepository, IBrandRepository brandRepository)
    {
        _productRepository = productRepository;
        _brandRepository = brandRepository;
    }

    public async Task<Product> GetProductById(Guid productId)
    {
        return await _productRepository.GetProductById(productId);
    }

    public async Task<Product> GetProductByName(NotNullString productName)
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
        Product product = createProductCommand.ToDomain(Guid.NewGuid(), brand);
        await _productRepository.Insert(product);

        return product;
    }
}