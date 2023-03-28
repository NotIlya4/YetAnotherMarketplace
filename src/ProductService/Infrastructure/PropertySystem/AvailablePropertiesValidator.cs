using Domain.Exceptions;
using Infrastructure.Extensions;
using Infrastructure.SortingSystem;

namespace Infrastructure.PropertySystem;

public class AvailablePropertiesValidator<TEntity>
{
    private readonly IEnumerable<PropertyName<TEntity>> _availableProperties;

    public AvailablePropertiesValidator(ICollection<string> rawAvailableProperties)
        : this(rawAvailableProperties.Select(p => new PropertyName<TEntity>(p)))
    {
        
    }

    public AvailablePropertiesValidator(IEnumerable<PropertyName<TEntity>> availableProperties)
    {
        _availableProperties = availableProperties;
    }

    public void Validate(PropertyName<TEntity> property)
    {
        if (!_availableProperties.Contains(property))
        {
            throw new ValidationException(
                $"{property.Value} isn't available, available are: {_availableProperties.Select(p => p.Value).ToReadableString()}");
        }
    }

    public void Validate(string propertyName)
    {
        Validate(new PropertyName<TEntity>(propertyName));
    }

    public void Validate(SortingInfo<TEntity> sortingInfo)
    {
        Validate(sortingInfo.PropertyName.Value);
    }

    public void Validate(IEnumerable<SortingInfo<TEntity>> sortingInfos)
    {
        foreach (var sortingInfo in sortingInfos)
        {
            Validate(sortingInfo);
        }
    }
}