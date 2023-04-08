using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Repositories.Extensions;

public static class DbContextExtensions
{
    public static void DeleteEntry<TEntity>(this DbContext dbContext, TEntity entity)
        where TEntity : class, IEntityComparable<TEntity>
    {
        EntityEntry<TEntity>? entry = dbContext.ChangeTracker.Entries<TEntity>()
            .FirstOrDefault(e => e.Entity.EqualId(entity));

        if (entry is not null)
        {
            entry.State = EntityState.Detached;
        }
    }

    public static void SetEntry<TEntity>(this DbContext dbContext, TEntity entity)
        where TEntity : class, IEntityComparable<TEntity>
    {
        dbContext.DeleteEntry(entity);
        dbContext.Entry(entity).State = EntityState.Unchanged;
    }
}