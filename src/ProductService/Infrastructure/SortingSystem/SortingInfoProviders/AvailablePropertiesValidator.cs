using Domain.Exceptions;
using Infrastructure.PropertySystem;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.SortingSystem.SortingInfoProviders;

public class AvailablePropertiesValidator<TEntity>
{
    private readonly List<string> _availablePropertyStrings;

    public AvailablePropertiesValidator(List<string> rawAvailableProperties) 
        : this(rawAvailableProperties.Select(s => new PropertyName<TEntity>(s)).ToList())
    {
        
    }

    public AvailablePropertiesValidator(List<PropertyName<TEntity>> availableProperties)
    {
        _availablePropertyStrings = availableProperties.Select(ap => ap.Value).ToList();
    }

    public void Validate(PropertyName<TEntity> propertyName)
    {
        if (!_availablePropertyStrings.Contains(propertyName.Value, StringComparer.OrdinalIgnoreCase))
        {
            throw new ValidationException(
                $"{propertyName.Value} property isn't available, available are: {_availablePropertyStrings.ToReadableString()}");
        }
    }
    
    public void Validate(SortingInfo<TEntity> sortingInfo)
    {
        Validate(sortingInfo.PropertyName);
    }

    public void Validate(IEnumerable<SortingInfo<TEntity>> sortingInfos)
    {
        foreach (var sortingInfo in sortingInfos)
        {
            Validate(sortingInfo);
        }
    }
}