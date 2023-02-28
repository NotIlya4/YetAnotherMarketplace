using Domain.Entities.Brand;

namespace Infrastructure.Data.Repositories.BrandRepository;

public interface IBrandRepository
{
    public Task<Brand> GetBrandByNameAsync(string brandName);
    public Task<Brand> GetBrandByIdAsync(BrandId brandId);
    public Task<List<Brand>> GetBrandsAsync();
    public Task InsertAsync(Brand brand);
}