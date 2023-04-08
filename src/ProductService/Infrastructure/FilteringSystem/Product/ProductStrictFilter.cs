namespace Infrastructure.FilteringSystem.Product;

public class ProductStrictFilter : IStrictFilter
{
    public ProductStrictFilterProperty Property { get; }
    public string PropertyName => Property.ToString();
    public string ExpectedValue { get; }

    public ProductStrictFilter(ProductStrictFilterProperty productProperty, string expectedValue)
    {
        Property = productProperty;
        ExpectedValue = expectedValue;
    }

    public ProductStrictFilter(string productPropertyName, string expectedValue) 
        : this(Enum.Parse<ProductStrictFilterProperty>(productPropertyName, true), expectedValue)
    {
        
    }
}