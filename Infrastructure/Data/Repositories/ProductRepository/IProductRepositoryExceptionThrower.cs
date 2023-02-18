using System.Diagnostics.CodeAnalysis;
using Domain.Entities.Product;

namespace Infrastructure.Data.Repositories.ProductRepository;

public interface IProductRepositoryExceptionThrower
{
    public void DidntFindAnyProduct([NotNull]Product? brand);
}