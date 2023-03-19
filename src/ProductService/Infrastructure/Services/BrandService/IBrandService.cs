using Domain.Entities;

namespace Infrastructure.Services.BrandService;

public interface IBrandService
{
    public Task<List<Brand>> GetBrands();
}