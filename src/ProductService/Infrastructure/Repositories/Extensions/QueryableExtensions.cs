using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.SortingSystem;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Extensions;

public static class QueryableExtensions
{
    public static async Task<TEntity> FirstAsyncOrThrow<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
    {
        return await query.FirstOrDefaultAsync(predicate) ?? throw new EntityNotFoundException(typeof(TEntity).Name);
    }
    
    public static async Task<TEntity> FirstAsyncOrThrow<TEntity>(this IQueryable<TEntity> query, IStrictFilter strictFilter)
    {
        query = query.Where("@0 == @1", strictFilter.PropertyName, strictFilter.ExpectedValue);
        return await query.FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(TEntity).Name);
    }

    public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> query, Pagination pagination)
    {
        return query
            .Skip(pagination.Offset)
            .Take(pagination.Limit);
    }
    
    public static IQueryable<TEntity> ApplySorting<TEntity>(this IQueryable<TEntity> query, ISortingInfo primarySorting,
        IEnumerable<ISortingInfo>? secondarySortings = null)
    {
        string BuildOrderString(ISortingInfo sortingInfo)
        {
            return $"{sortingInfo.PropertyName} {sortingInfo.SortingSide}";
        }
        
        IOrderedQueryable<TEntity> orderedQueryable = query.OrderBy(BuildOrderString(primarySorting));

        if (secondarySortings is null)
        {
            return orderedQueryable;
        }
        
        foreach (var secondarySorting in secondarySortings)
        {
            orderedQueryable =
                orderedQueryable.ThenBy(BuildOrderString(secondarySorting));
        }

        return orderedQueryable;
    }
}