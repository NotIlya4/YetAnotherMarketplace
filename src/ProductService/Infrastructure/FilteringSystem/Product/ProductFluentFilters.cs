using Domain.Primitives;

namespace Infrastructure.FilteringSystem.Product;

public class ProductFluentFilters
{
    public Name? ProductTypeName { get; }
    public Name? BrandName { get; }
    public Name? Searching { get; }

    public ProductFluentFilters(Name? productTypeName, Name? brandName, Name? searching)
    {
        ProductTypeName = productTypeName;
        BrandName = brandName;
        Searching = searching;
    }
}