using Domain.Exceptions;

namespace Infrastructure.PropertySystem;

public readonly record struct PropertyName<TClass>
{
    public string Value { get; }

    public PropertyName(string propertyName)
    {
        List<string> properties = typeof(TClass).GetProperties().Select(p => p.Name).ToList();

        string? nameFromType = properties.FirstOrDefault(p => p.EqualsIgnoreCase(propertyName));

        Value = nameFromType ?? throw new ValidationException(
            $"Bad property name {propertyName}, available are: {properties.ToReadableString()}");
    }
}