namespace Infrastructure.EntityFramework.Models;

public interface IEntity<in TEntity>
{
    public bool EqualId(TEntity entity);
}