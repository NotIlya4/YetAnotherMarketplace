using Domain.Primitives;
using Infrastructure.Repositories.Primitives;
using Infrastructure.Services.BrandService.Dtos;

namespace Infrastructure.Services.BrandService;

public interface IBrandService
{
    public Task<GetBrandDto> GetBrandById(Guid brandId);
    public Task<GetBrandDto> GetBrandByName(NotNullString brandName);
    public Task<List<GetBrandDto>> GetBrands(Pagination pagination);
    public Task<GetBrandDto> CreateNewBrand(CreateBrandDto createBrandDto);
}