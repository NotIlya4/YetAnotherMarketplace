namespace Domain.Interfaces;

public interface IEntityComparable<TEntity>
{
    public bool EqualId(TEntity entity);
}