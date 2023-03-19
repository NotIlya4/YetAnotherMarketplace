using Domain.Exceptions;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.SortingSystem.SortingInfoProviders;

public class AvailablePropertiesValidator<TEntity>
{
    private readonly List<string> _availablePropertyStrings;

    public AvailablePropertiesValidator(List<string> rawAvailableProperties) 
        : this(rawAvailableProperties.Select(p => new PropertyName<TEntity>(p)).ToList())
    {
        
    }
    
    public AvailablePropertiesValidator(List<PropertyName<TEntity>> availableProperties)
    {
        _availablePropertyStrings = availableProperties.Select(p => p.Value).ToList();
    }

    public void Validate(string propertyName)
    {
        if (!_availablePropertyStrings.Contains(propertyName, StringComparer.OrdinalIgnoreCase))
        {
            throw new ValidationException(
                $"{propertyName} property isn't available, available are: {_availablePropertyStrings.ToReadableString()}");
        }
    }

    public void Validate(IEnumerable<SortingInfo<TEntity>> sortingInfos)
    {
        foreach (var sortingInfo in sortingInfos)
        {
            Validate(sortingInfo.PropertyName.Value);
        }
    }
}