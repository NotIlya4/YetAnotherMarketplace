using System.Diagnostics.CodeAnalysis;
using Domain.Entities.Brand;

namespace Infrastructure.Data.Repositories.BrandRepository;

public interface IBrandRepositoryExceptionThrower
{
    public void DidntFindAnyBrand([NotNull] Brand? brand);
}