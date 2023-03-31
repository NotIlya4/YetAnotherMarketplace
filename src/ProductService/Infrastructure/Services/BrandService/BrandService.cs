using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Repositories.BrandRepository;

namespace Infrastructure.Services.BrandService;

public class BrandService : IBrandService
{
    private readonly IBrandsRepository _brandsRepository;

    public BrandService(IBrandsRepository brandsRepository)
    {
        _brandsRepository = brandsRepository;
    }

    public async Task<List<Brand>> GetBrands()
    {
        return await _brandsRepository.GetBrands();
    }

    public async Task<Brand> Add(Name brandName)
    {
        Brand brand = new Brand(Guid.NewGuid(), brandName);
        await _brandsRepository.Insert(brand);
        return brand;
    }

    public async Task Delete(Name brandName)
    {
        Brand brandToDelete = await _brandsRepository.GetBrand(brandName);
        await _brandsRepository.Delete(brandToDelete);
    }
}