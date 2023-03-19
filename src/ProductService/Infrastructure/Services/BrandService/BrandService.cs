using Domain.Entities;
using Infrastructure.Repositories.BrandRepository;

namespace Infrastructure.Services.BrandService;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<List<Brand>> GetBrands()
    {
        return await _brandRepository.GetAll();
    }
}