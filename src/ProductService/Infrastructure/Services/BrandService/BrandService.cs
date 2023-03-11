using Domain.Entities;
using Domain.Primitives;
using Infrastructure.ListQuery;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.SortingSystem;

namespace Infrastructure.Services.BrandService;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<Brand> GetBrandById(Guid brandId)
    {
        return await _brandRepository.GetBrandById(brandId);
    }

    public async Task<Brand> GetBrandByName(NotNullString brandName)
    {
        return await _brandRepository.GetBrandByName(brandName);
    }

    public async Task<List<Brand>> GetBrands(Pagination pagination, BrandSortingInfoProvider brandSortingInfoProvider)
    {
        return await _brandRepository.GetBrands(pagination, brandSortingInfoProvider);
    }

    public async Task<Brand> CreateNewBrand(CreateBrandDto createBrandDto)
    {
        Brand brand = createBrandDto.ToDomain(Guid.NewGuid());

        await _brandRepository.Insert(brand);

        return brand;
    }
}