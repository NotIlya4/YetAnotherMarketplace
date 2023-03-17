using Domain.Exceptions;

namespace Domain.Primitives;

public record struct Description : IComparable<Description>
{
    public string Value { get; private set; }
    
    public const int DescriptionMinLength = 10;
    public const int DescriptionMaxLength = 150;

    public Description(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException($"Description must be between {DescriptionMinLength} and {DescriptionMaxLength} in length");
        }
        
        if (value.Length is not (>= DescriptionMinLength and <= DescriptionMaxLength))
        {
            throw new ValidationException($"Description must be between {DescriptionMinLength} and {DescriptionMaxLength} in length");
        }

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public int CompareTo(Description other)
    {
        return string.Compare(Value, other.Value, StringComparison.Ordinal);
    }
}