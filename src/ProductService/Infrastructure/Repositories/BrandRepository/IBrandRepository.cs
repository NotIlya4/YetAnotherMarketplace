using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Repositories.Primitives;

namespace Infrastructure.Repositories.BrandRepository;

public interface IBrandRepository
{
    public Task<Brand> GetBrandByNameAsync(NotNullString brandName);
    public Task<Brand> GetBrandByIdAsync(Guid brandId);
    public Task<List<Brand>> GetBrandsAsync(Pagination pagination);
    public Task InsertAsync(Brand brand);
}