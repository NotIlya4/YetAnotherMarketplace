using Infrastructure.SortingSystem.Models;

namespace Infrastructure.Repositories;

public interface ISortingApplier<TEntity>
{
    IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, SortingInfo<TEntity> primarySorting,
        IEnumerable<SortingInfo<TEntity>>? secondarySortings = null);
}