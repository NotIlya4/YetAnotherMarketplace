namespace Infrastructure.FilteringSystem.Product;

public class ProductStrictFilter : IStrictFilter
{
    public string PropertyName { get; }
    public string ExpectedValue { get; }

    public ProductStrictFilter(ProductStrictFilterProperty productProperty, string expectedValue)
    {
        PropertyName = productProperty.ToString();
        ExpectedValue = expectedValue;
    }

    public ProductStrictFilter(string productPropertyName, string expectedValue) 
        : this(Enum.Parse<ProductStrictFilterProperty>(productPropertyName, true), expectedValue)
    {
        
    }
}