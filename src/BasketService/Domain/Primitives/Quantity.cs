using Domain.Exceptions;

namespace Domain.Primitives;

public readonly record struct Quantity
{
    public int Value { get; }

    public Quantity(int value)
    {
        if (!(value >= 0))
        {
            throw new ValidationException("Quantity must be bigger than 0");
        }

        Value = value;
    }
}