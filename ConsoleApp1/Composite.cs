namespace ConsoleApp1;

public class Composite : IEquatable<Composite>
{
    private readonly Type _mapperType;
    private readonly Type _exceptionType;

    public Composite(Type mapperType, Type exceptionType)
    {
        _mapperType = mapperType;
        _exceptionType = exceptionType;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Composite otherComposite)
        {
            return Equals(otherComposite);
        }

        return false;
    }

    public bool Equals(Composite? other)
    {
        if (other is null)
        { 
            return false;
        }

        return _mapperType.Equals(other._mapperType) && _exceptionType.Equals(other._exceptionType);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_mapperType, _exceptionType);
    }
}