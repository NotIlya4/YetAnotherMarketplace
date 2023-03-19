using System.Linq.Expressions;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Extensions;

public static class QueryableExtensions
{
    public static async Task<TEntity> FirstAsyncOrThrow<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
    {
        return await query.FirstOrDefaultAsync(predicate) ?? throw new EntityNotFoundException(typeof(TEntity).Name);
    }

    public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> query, Pagination pagination)
    {
        return query
            .Skip(pagination.Offset)
            .Take(pagination.Limit);
    }
}