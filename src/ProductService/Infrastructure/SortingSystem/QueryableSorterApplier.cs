using Infrastructure.SortingSystem.Core;

namespace Infrastructure.SortingSystem;

public class QueryableSorterApplier
{
    public IQueryable<TEntity> ApplySorting<TEntity>(IQueryable<TEntity> query, ISortingInfoProvider<TEntity> sortingInfoProvider)
    {
        IOrderedQueryable<TEntity> orderedQueryable = ApplyOrderBy(query, sortingInfoProvider.PrimarySorting);

        foreach (var propertySortingInfo in sortingInfoProvider.SecondarySortings)
        {
            orderedQueryable = ApplyThenBy(orderedQueryable, propertySortingInfo);
        }

        return orderedQueryable;
    }

    private IOrderedQueryable<TEntity> ApplyOrderBy<TEntity>(IQueryable<TEntity> query, IPropertySortingInfoProvider<TEntity> propertySorting)
    {
        return propertySorting.SortingSide == SortingSide.Asc ? query.OrderBy(propertySorting.PropertyLambda) : query.OrderByDescending(propertySorting.PropertyLambda);
    }
    
    private IOrderedQueryable<TEntity> ApplyThenBy<TEntity>(IOrderedQueryable<TEntity> query, IPropertySortingInfoProvider<TEntity> propertySorting)
    {
        return propertySorting.SortingSide == SortingSide.Asc ? query.ThenBy(propertySorting.PropertyLambda) : query.ThenByDescending(propertySorting.PropertyLambda);
    }
}