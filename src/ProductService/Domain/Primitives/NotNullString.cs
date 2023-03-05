using System.ComponentModel.DataAnnotations;

namespace Domain.Primitives;

public record struct NotNullString
{
    public string Value { get; private set; }

    public NotNullString(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException("String must contain at least 1 char");
        }

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}