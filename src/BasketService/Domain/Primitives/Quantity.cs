using Domain.Exceptions;

namespace Domain.Primitives;

public record struct Quantity
{
    public int Value { get; private set; }

    public Quantity(int value)
    {
        if (!(value >= 0))
        {
            throw new ValidationException("Quantity must be bigger than 0");
        }

        Value = value;
    }
}