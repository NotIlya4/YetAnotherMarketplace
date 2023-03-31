using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Repositories.BrandRepository;

public interface IBrandsRepository
{
    public Task<List<Brand>> GetBrands();
    public Task<Brand> GetBrand(Name name);
    public Task Insert(Brand brand);
    public Task Delete(Brand brand);
}