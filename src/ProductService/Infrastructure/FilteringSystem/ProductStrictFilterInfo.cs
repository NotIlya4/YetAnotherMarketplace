using Domain.Entities;
using Infrastructure.PropertySystem;

namespace Infrastructure.FilteringSystem;

public class ProductStrictFilterInfo
{
    public PropertyName<Product> PropertyName { get; }
    public string ExpectedValue { get; }

    public static List<string> AvailableProperties { get; } = new()
    {
        nameof(Product.Id),
        nameof(Product.Name)
    };

    private static AvailablePropertiesValidator<Product> AvailablePropertiesValidator { get; } =
        new(AvailableProperties);

    public ProductStrictFilterInfo(PropertyName<Product> propertyName, string expectedValue)
    {
        AvailablePropertiesValidator.Validate(propertyName);
        
        PropertyName = propertyName;
        ExpectedValue = expectedValue;
    }
}