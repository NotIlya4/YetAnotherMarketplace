using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<T> GetByIdAsync(int id);

    public Task<IReadOnlyList<T>> GetAllAsync();

    public Task<T> GetEntityWithSpec(ISpecification<T> spec);

    public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
}