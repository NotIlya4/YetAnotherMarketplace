using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.SortingInfoProviders;

namespace Infrastructure.Services.BrandService;

public interface IBrandService
{
    public Task<Brand> GetBrandByName(Name brandName);
    public Task<List<Brand>> GetBrands();
    public Task<Brand> CreateNewBrand(CreateBrandCommand createBrandCommand);
    public Task DeleteBrandByName(Name brandName);
}