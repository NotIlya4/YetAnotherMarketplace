using Domain.Exceptions;

namespace Domain.Primitives;

public record struct Price : IComparable<Price>
{
    public decimal Value { get; private set; }
    
    public Price(decimal value)
    {
        if (value < 0)
        {
            throw new ValidationException("Price must be greater than 0");
        }

        Value = value;
    }

    public int CompareTo(Price other)
    {
        return Value.CompareTo(other.Value);
    }
}