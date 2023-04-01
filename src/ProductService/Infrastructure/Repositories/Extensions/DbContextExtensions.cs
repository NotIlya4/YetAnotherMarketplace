using Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Repositories.Extensions;

public static class DbContextExtensions
{
    public static EntityEntry<TEntity> SetEntry<TEntity>(this DbContext dbContext,
        TEntity entity) where TEntity : class, IEntity<TEntity>
    {
        EntityEntry<TEntity>? entry = dbContext.ChangeTracker.Entries<TEntity>()
            .FirstOrDefault(e => e.Entity.EqualId(entity));

        if (entry is not null)
        {
            entry.State = EntityState.Detached;
        }

        return dbContext.Entry(entity);
    }
}