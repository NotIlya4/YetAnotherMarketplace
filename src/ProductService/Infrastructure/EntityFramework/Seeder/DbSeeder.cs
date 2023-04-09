using Infrastructure.EntityFramework.Models;
using Infrastructure.Extensions;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;

namespace Infrastructure.EntityFramework.Seeder;

public class DbSeeder
{
    private readonly IServiceProvider _services;
    private readonly IEnumerable<BrandData> _brandDatas;
    private readonly IEnumerable<ProductTypeData> _productTypeDatas;
    private readonly IEnumerable<ProductData> _productDatas;


    public DbSeeder(IServiceProvider services, IEnumerable<BrandData> brandDatas, IEnumerable<ProductTypeData> productTypeDatas, IEnumerable<ProductData> productDatas)
    {
        _services = services;
        _brandDatas = brandDatas;
        _productTypeDatas = productTypeDatas;
        _productDatas = productDatas;
    }
    
    public async Task Seed()
    {
        await _services.UsingScope<ApplicationDbContext>(async dbContext => { await dbContext.SetBrands(_brandDatas); });
        await _services.UsingScope<ApplicationDbContext>(async dbContext => { await dbContext.SetProductTypes(_productTypeDatas); });
        await _services.UsingScope<ApplicationDbContext>(async dbContext => { await dbContext.SetProducts(_productDatas); });
    }
}