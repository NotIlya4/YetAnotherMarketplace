namespace Domain.Primitives;

public class GuidId : IEquatable<GuidId>
{
    public GuidId(Guid id)
    {
        Id = id;
    }

    public GuidId(string id)
    {
        Id = Guid.Parse(id);
    }

    public Guid Id { get; }

    public bool Equals(GuidId? other)
    {
        if (other is null) return false;

        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is GuidId guidId) return Equals(guidId);

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return Id.ToString();
    }
}