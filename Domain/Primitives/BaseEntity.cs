namespace Domain.Primitives;

public abstract class BaseModel<TId>
{
    public BaseModel(TId id)
    {
        Id = id;
    }

    public TId Id { get; }

    public override bool Equals(object? obj)
    {
        if (obj is BaseModel<TId> baseEntity) return Equals(baseEntity);

        return false;
    }

    public bool Equals(BaseModel<TId> other)
    {
        if (Id is null) return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        if (Id is null) return 0;

        return Id.GetHashCode();
    }
}