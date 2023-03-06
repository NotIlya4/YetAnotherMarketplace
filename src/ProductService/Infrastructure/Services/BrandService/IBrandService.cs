using Domain.Entities;
using Domain.Primitives;
using Infrastructure.ListQuery;

namespace Infrastructure.Services.BrandService;

public interface IBrandService
{
    public Task<Brand> GetBrandById(Guid brandId);
    public Task<Brand> GetBrandByName(NotNullString brandName);
    public Task<List<Brand>> GetBrands(Pagination pagination, SortingType sortingType);
    public Task<Brand> CreateNewBrand(CreateBrandDto createBrandDto);
}