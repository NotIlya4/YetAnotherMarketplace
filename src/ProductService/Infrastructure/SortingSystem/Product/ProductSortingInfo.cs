namespace Infrastructure.SortingSystem.Product;

public readonly record struct ProductSortingInfo : ISortingInfo
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }

    public ProductSortingInfo(ProductSortingProperty property, SortingSide sortingSide)
    {
        PropertyName = property.ToString();
        SortingSide = sortingSide;
    }

    public ProductSortingInfo(string propertyName, SortingSide sortingSide)
        : this(Enum.Parse<ProductSortingProperty>(propertyName, true), sortingSide)
    {
        
    }
}