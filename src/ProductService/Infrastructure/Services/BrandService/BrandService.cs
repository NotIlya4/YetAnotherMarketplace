using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Repositories.BrandRepository;

namespace Infrastructure.Services.BrandService;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<List<Brand>> GetBrands()
    {
        return await _brandRepository.GetAll();
    }

    public async Task<Brand> Add(Name brandName)
    {
        Brand brand = new Brand(Guid.NewGuid(), brandName);
        await _brandRepository.Insert(brand);
        return brand;
    }

    public async Task Delete(Name brandName)
    {
        Brand brandToDelete = await _brandRepository.GetBrandByName(brandName);
        await _brandRepository.Delete(brandToDelete);
    }
}