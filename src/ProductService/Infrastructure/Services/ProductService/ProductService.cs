using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Primitives;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Services.ProductService.Dtos;

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

    public async Task<GetProductDto> GetProductById(Guid productId)
    {
        var product = await _productRepository.GetProductByIdAsync(productId);
        return GetProductDto.FromDomainModel(product);
    }

    public async Task<GetProductDto> GetProductByName(NotNullString productName)
    {
        return GetProductDto.FromDomainModel(await _productRepository.GetProductByNameAsync(productName));
    }

    public async Task<List<GetProductDto>> GetProducts(Pagination pagination)
    {
        var products = await _productRepository
            .GetProductsAsync(pagination);
        return products.Select(GetProductDto.FromDomainModel).ToList();
    }

    public async Task<GetProductDto> CreateNewProduct(CreateProductDto createProductDto)
    {
        Brand brand = await _brandRepository.GetBrandByNameAsync(createProductDto.BrandName);
        Product product = createProductDto.ToDomain(Guid.NewGuid(), brand);
        await _productRepository.InsertAsync(product);
        
        return GetProductDto.FromDomainModel(product);
    }
}