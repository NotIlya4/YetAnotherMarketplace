namespace Domain;

public interface IEntityComparable<TEntity>
{
    public bool EqualId(TEntity? entity);
}