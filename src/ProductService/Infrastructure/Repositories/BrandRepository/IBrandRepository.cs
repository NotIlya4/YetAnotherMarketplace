using Domain.Primitives;

namespace Infrastructure.Repositories.BrandRepository;

public interface IBrandRepository
{
    public Task<List<Name>> GetBrands();
    public Task Add(Name brand);
    public Task Delete(Name brand);
}