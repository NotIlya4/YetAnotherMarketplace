using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.QueryableExtensions;

public static class QueryableExtensions
{
    public static async Task<TEntity> FirstAsyncOrThrow<TRepository, TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
    {
        return await query.FirstOrDefaultAsync(predicate) ?? throw new EntityNotFoundException(typeof(TEntity), typeof(TRepository));
    }
}