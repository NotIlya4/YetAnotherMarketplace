namespace Infrastructure.SortingSystem.Product;

public readonly record struct ProductSorting : ISorting
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }

    public ProductSorting(ProductSortingProperty property, SortingSide sortingSide)
    {
        PropertyName = property.ToString();
        SortingSide = sortingSide;
    }

    public ProductSorting(string propertyName, SortingSide sortingSide)
        : this(Enum.Parse<ProductSortingProperty>(propertyName, true), sortingSide)
    {
        
    }
}