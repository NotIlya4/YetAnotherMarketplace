using Domain.Entities.Brand;
using Domain.Entities.Product;
using Infrastructure.Data.Repositories.BrandRepository;
using Infrastructure.Data.Repositories.ProductRepository;
using Infrastructure.ProductService.Dtos;

namespace Infrastructure.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IProductIdFactory _productIdFactory;

    public ProductService(IProductRepository productRepository, IBrandRepository brandRepository, IProductIdFactory productIdFactory)
    {
        _productRepository = productRepository;
        _brandRepository = brandRepository;
        _productIdFactory = productIdFactory;
    }

    public async Task<GetProductDto> GetProductById(string id)
    {
        var product = await _productRepository.GetProductByIdAsync(new ProductId(id));
        return GetProductDto.FromDomainModel(product);
    }

    public async Task<GetProductDto> GetProductByName(string name)
    {
        return GetProductDto.FromDomainModel(await _productRepository.GetProductByNameAsync(name));
    }

    public async Task<List<GetProductDto>> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();
        return products.Select(GetProductDto.FromDomainModel).ToList();
    }

    public async Task CreateNewProduct(CreateProductDto createProductDto)
    {
        Brand brand = await _brandRepository.GetBrandByName(createProductDto.BrandName);
        Product product = createProductDto.ToDomain(_productIdFactory.CreateProductId(), brand);
        await _productRepository.InsertAsync(product);
    }
}