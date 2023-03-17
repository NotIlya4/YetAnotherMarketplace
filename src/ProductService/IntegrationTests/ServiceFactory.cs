using Infrastructure.EntityFramework;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;
using Infrastructure.Services.BrandService;
using Infrastructure.Services.ProductService;

namespace IntegrationTests;

public class ServiceFactory
{
    public static ProductService CreateProductService(DatabaseProvider databaseProvider)
    {
        ProductTypeRepository productTypeRepository = databaseProvider.ProductTypeRepository;
        BrandRepository brandRepository = databaseProvider.BrandRepository;
        ProductRepository productRepository = databaseProvider.ProductRepository;
        
        return new ProductService(productRepository, brandRepository, productTypeRepository);
    }
}