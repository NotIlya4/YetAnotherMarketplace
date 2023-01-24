using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<T> GetByIdAsync(int id);

    public Task<IReadOnlyList<T>> GetAllAsync();
}