using Infrastructure.PropertySystem;

namespace Infrastructure.SortingSystem.Core;

public interface ISortingInfo<TEntity>
{
    PropertyName<TEntity> PropertyName { get; }
    SortingSide SortingSide { get; }
}