using Infrastructure.BrandService.Dtos;

namespace Infrastructure.BrandService;

public interface IBrandService
{
    public Task<GetBrandDto> GetBrandById(string id);
    public Task<GetBrandDto> GetBrandByName(string name);
    public Task<List<GetBrandDto>> GetBrands();
    public Task<GetBrandDto> CreateNewBrand(CreateBrandDto createBrandDto);
}