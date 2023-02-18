using Domain.Entities.Brand;

namespace Infrastructure.Data.Repositories.BrandRepository;

public interface IBrandRepository
{
    public Task<Brand> GetBrandByName(string brandName);
    public Task<Brand> GetBrandById(BrandId brandId);
    public Task<List<Brand>> GetBrands();
    public Task Insert(Brand brand);
}