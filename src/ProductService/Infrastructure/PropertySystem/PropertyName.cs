using Domain.Exceptions;
using Infrastructure.Extensions;

namespace Infrastructure.PropertySystem;

public readonly record struct PropertyName<TClass>
{
    public string Value { get; }

    public PropertyName(string propertyName)
    {
        string? nameFromType = typeof(TClass)
            .GetProperties()
            .Select(p => p.Name)
            .FirstOrDefault(p => p.EqualsIgnoreCase(propertyName));

        Value = nameFromType ?? throw new ValidationException(
            $"{typeof(TClass).Name} doesn't contain {propertyName} property");
    }

    public override string ToString()
    {
        return Value;
    }
}