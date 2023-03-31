using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;

namespace Infrastructure.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IProductsRepository _productsRepository;
    private readonly IBrandsRepository _brandsRepository;
    private readonly IProductTypesRepository _productTypesRepository;

    public ProductService(IProductsRepository productsRepository, IBrandsRepository brandsRepository,
        IProductTypesRepository productTypesRepository)
    {
        _productsRepository = productsRepository;
        _brandsRepository = brandsRepository;
        _productTypesRepository = productTypesRepository;
    }

    public async Task<Product> GetProduct(ProductStrictFilter filter)
    {
        return await _productsRepository.GetProduct(filter);
    }

    public async Task<Product> CreateNewProduct(CreateProductCommand createProductCommand)
    {
        ProductType productType = await _productTypesRepository.GetProductType(createProductCommand.ProductTypeName);
        Brand brand = await _brandsRepository.GetBrand(createProductCommand.BrandName);

        Product product = createProductCommand.ToDomain(Guid.NewGuid(), brand, productType);

        await _productsRepository.Insert(product);

        return product;
    }

    public async Task<GetProductsResult> GetProducts(GetProductsQuery query)
    {
        List<Product> products = await _productsRepository.GetProducts(query);
        int total = await _productsRepository.GetProductsCountForFilters(query.FluentFilters);
        return new GetProductsResult()
        {
            Products = products,
            Total = total
        };
    }

    public async Task DeleteProduct(ProductStrictFilter filter)
    {
        Product product = await _productsRepository.GetProduct(filter);
        await _productsRepository.Delete(product);
    }
}