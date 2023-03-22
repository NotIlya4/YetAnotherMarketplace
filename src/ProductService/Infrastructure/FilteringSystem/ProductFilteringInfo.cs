using Domain.Primitives;

namespace Infrastructure.FilteringSystem;

public class ProductFilteringInfo
{
    public Name? ProductTypeName { get; }
    public Name? BrandName { get; }
    public Name? Searching { get; }

    public ProductFilteringInfo(Name? productTypeName, Name? brandName, Name? searching)
    {
        ProductTypeName = productTypeName;
        BrandName = brandName;
        Searching = searching;
    }
}