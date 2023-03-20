using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.BrandService;

public interface IBrandService
{
    public Task<List<Brand>> GetBrands();
    public Task<Brand> Add(Name brandName);
    public Task Delete(Name brandName);
}