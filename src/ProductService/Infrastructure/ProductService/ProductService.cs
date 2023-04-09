using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Repositories.ProductRepository;

namespace Infrastructure.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> GetProduct(ProductStrictFilter filter)
    {
        return await _productRepository.GetProduct(filter);
    }

    public async Task<Product> CreateNewProduct(CreateProductCommand createProductCommand)
    {
        Product product = new Product(
            id: Guid.NewGuid(),
            name: createProductCommand.Name,
            description: createProductCommand.Description,
            price: createProductCommand.Price,
            pictureUrl: createProductCommand.PictureUrl,
            productType: createProductCommand.ProductType,
            brand: createProductCommand.Brand);

        await _productRepository.Insert(product);

        return product;
    }

    public async Task DeleteProduct(ProductStrictFilter filter)
    {
        await _productRepository.Delete(filter);
    }

    public async Task<GetProductsResult> GetProducts(GetProductsQuery query)
    {
        List<Product> products = await _productRepository.GetProducts(query);
        int total = await _productRepository.GetProductsCountForFilters(query.FluentFilters);
        return new GetProductsResult()
        {
            Products = products,
            Total = total
        };
    }
}