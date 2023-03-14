using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.BrandService;

public interface IBrandService
{
    public Task<Brand> GetBrandById(Guid brandId);
    public Task<Brand> GetBrandByName(NotNullString brandName);
    public Task<List<Brand>> GetBrands(Pagination pagination, BrandSortingInfo brandSortingInfo);
    public Task<Brand> CreateNewBrand(CreateBrandDto createBrandDto);
    public Task DeleteBrandById(Guid brandId);
    public Task DeleteBrandByName(NotNullString brandName);
}