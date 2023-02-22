using Domain.Entities.Brand;
using Infrastructure.BrandService.Dtos;
using Infrastructure.Data.Repositories.BrandRepository;

namespace Infrastructure.BrandService;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IBrandIdFactory _brandIdFactory;

    public BrandService(IBrandRepository brandRepository, IBrandIdFactory brandIdFactory)
    {
        _brandRepository = brandRepository;
        _brandIdFactory = brandIdFactory;
    }

    public async Task<GetBrandDto> GetBrandById(string id)
    {
        return GetBrandDto.FromDomain(await _brandRepository.GetBrandByIdAsync(new BrandId(id)));
    }

    public async Task<GetBrandDto> GetBrandByName(string name)
    {
        return GetBrandDto.FromDomain(await _brandRepository.GetBrandByNameAsync(name));
    }

    public async Task<List<GetBrandDto>> GetBrands()
    {
        return (await _brandRepository.GetBrandsAsync()).Select(GetBrandDto.FromDomain).ToList();
    }

    public async Task<GetBrandDto> CreateNewBrand(CreateBrandDto createBrandDto)
    {
        Brand brand = createBrandDto.ToDomain(_brandIdFactory.CreateBrandId());

        await _brandRepository.InsertAsync(brand);
        
        return GetBrandDto.FromDomain(brand);
    }
}