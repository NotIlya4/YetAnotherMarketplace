using Domain.Exceptions;

namespace Domain.Primitives;

public record struct Name : IComparable<Name>
{
    public string Value { get; private set; }

    public Name(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException("Name must have at least 1 char");
        }

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public int CompareTo(Name other)
    {
        return string.Compare(Value, other.Value, StringComparison.Ordinal);
    }
}