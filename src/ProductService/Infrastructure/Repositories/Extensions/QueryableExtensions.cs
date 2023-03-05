using System.Linq.Expressions;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.Repositories.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Extensions;

public static class QueryableExtensions
{
    public static async Task<TEntity> FirstAsyncOrThrow<TRepository, TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
    {
        return await query.FirstOrDefaultAsync(predicate) ?? throw new EntityNotFoundException(typeof(TEntity), typeof(TRepository));
    }

    public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> query, Pagination pagination)
    {
        return query
            .Skip(pagination.Offset)
            .Take(pagination.Limit);
    }
}