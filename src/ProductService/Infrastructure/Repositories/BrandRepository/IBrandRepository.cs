using Domain.Entities;
using Domain.Primitives;
using Infrastructure.ListQuery;

namespace Infrastructure.Repositories.BrandRepository;

public interface IBrandRepository
{
    public Task<Brand> GetBrandByName(NotNullString brandName);
    public Task<Brand> GetBrandById(Guid brandId);
    public Task<List<Brand>> GetBrands(Pagination pagination, SortingType sortingType);
    public Task Insert(Brand brand);
}