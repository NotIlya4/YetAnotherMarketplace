using Domain.Exceptions;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.SortingSystem.SortingInfoProviders;

public class AvailablePropertiesValidator
{
    private readonly List<string> _availablePropertyStrings;

    public AvailablePropertiesValidator(List<string> availableProperties)
    {
        _availablePropertyStrings = availableProperties;
    }

    public void Validate(string propertyName)
    {
        if (!_availablePropertyStrings.Contains(propertyName, StringComparer.OrdinalIgnoreCase))
        {
            throw new ValidationException(
                $"{propertyName} property isn't available, available are: {_availablePropertyStrings.ToReadableString()}");
        }
    }

    public void Validate(IEnumerable<ISortingInfo> sortingInfos)
    {
        foreach (var sortingInfo in sortingInfos)
        {
            Validate(sortingInfo.PropertyName);
        }
    }
}