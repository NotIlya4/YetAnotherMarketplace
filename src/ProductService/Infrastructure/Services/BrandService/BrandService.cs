using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Primitives;
using Infrastructure.Services.BrandService.Dtos;

namespace Infrastructure.Services.BrandService;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<GetBrandDto> GetBrandById(Guid brandId)
    {
        return GetBrandDto.FromDomain(await _brandRepository.GetBrandByIdAsync(brandId));
    }

    public async Task<GetBrandDto> GetBrandByName(NotNullString brandName)
    {
        return GetBrandDto.FromDomain(await _brandRepository.GetBrandByNameAsync(brandName));
    }

    public async Task<List<GetBrandDto>> GetBrands(Pagination pagination)
    {
        return (await _brandRepository.GetBrandsAsync(pagination)).Select(GetBrandDto.FromDomain).ToList();
    }

    public async Task<GetBrandDto> CreateNewBrand(CreateBrandDto createBrandDto)
    {
        Brand brand = createBrandDto.ToDomain(Guid.NewGuid());

        await _brandRepository.InsertAsync(brand);
        
        return GetBrandDto.FromDomain(brand);
    }
}