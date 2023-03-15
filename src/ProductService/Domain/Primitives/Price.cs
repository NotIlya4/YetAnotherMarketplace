using Domain.Exceptions;

namespace Domain.Primitives;

public struct Price
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
}