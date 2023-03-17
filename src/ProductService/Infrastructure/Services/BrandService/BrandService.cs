using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.BrandService;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<Brand> GetBrandByName(Name brandName)
    {
        return await _brandRepository.GetBrandByName(brandName);
    }

    public async Task<List<Brand>> GetBrands()
    {
        return await _brandRepository.GetBrands();
    }

    public async Task<Brand> CreateNewBrand(CreateBrandCommand createBrandCommand)
    {
        Brand brand = createBrandCommand.ToDomain(Guid.NewGuid());

        await _brandRepository.Insert(brand);

        return brand;
    }

    public async Task DeleteBrandByName(Name brandName)
    {
        Brand brand = await _brandRepository.GetBrandByName(brandName);
        await _brandRepository.Delete(brand);
    }
}