using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Repositories.BrandRepository;

public interface IBrandRepository
{
    public Task<List<Brand>> GetAll();
    public Task<Brand> GetBrandByName(Name name);
    public Task Insert(Brand brand);
    public Task Delete(Brand brand);
}