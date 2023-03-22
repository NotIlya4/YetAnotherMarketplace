using Domain.Entities;
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

    public async Task<Product> GetProductById(Guid id)
    {
        return await _productRepository.GetProductById(id);
    }

    public async Task<Product> CreateNewProduct(CreateProductCommand createProductCommand)
    {
        ProductType productType = await _productTypeRepository.GetProductTypeByName(createProductCommand.ProductTypeName);
        Brand brand = await _brandRepository.GetBrandByName(createProductCommand.BrandName);

        Product product = createProductCommand.ToDomain(Guid.NewGuid(), brand, productType);

        await _productRepository.Insert(product);

        return product;
    }

    public async Task<GetProductsResult> GetProducts(GetProductsQuery query)
    {
        List<Product> products = await _productRepository.GetProducts(query);
        int total = await _productRepository.GetProductsCount(query.FilteringInfo);
        return new GetProductsResult()
        {
            Products = products,
            Total = total
        };
    }

    public async Task DeleteProductById(Guid id)
    {
        Product product = await _productRepository.GetProductById(id);
        await _productRepository.Delete(product);
    }
}