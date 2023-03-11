using Domain.Exceptions;
using Infrastructure.PropertySystem;
using Infrastructure.SortingSystem.Core;

namespace Infrastructure.SortingSystem;

public class AvailablePropertiesValidator<TEntity>
{
    private readonly List<string> _availablePropertyStrings;

    public AvailablePropertiesValidator(List<string> rawAvailableProperties) 
        : this(rawAvailableProperties.Select(s => new PropertyName<TEntity>(s)).ToList())
    {
        
    }

    public AvailablePropertiesValidator(List<PropertyName<TEntity>> availableProperties)
    {
        _availablePropertyStrings = availableProperties.Select(ap => ap.Value.ToLower()).ToList();
    }

    public void Validate(PropertyName<TEntity> propertyName)
    {
        if (!_availablePropertyStrings.Contains(propertyName.Value, StringComparer.OrdinalIgnoreCase))
        {
            throw new ValidationException(
                $"Bad property {propertyName}, available are: {_availablePropertyStrings}");
        }
    }

    public void Validate(IEnumerable<PropertySortingInfo<TEntity>> sortingInfos)
    {
        foreach (var sortingInfo in sortingInfos)
        {
            Validate(sortingInfo.PropertyName);
        }
    }
}