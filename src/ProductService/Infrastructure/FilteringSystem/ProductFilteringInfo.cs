using Domain.Primitives;

namespace Infrastructure.FilteringSystem;

public class ProductFilteringInfo
{
    public Name? ProductTypeName { get; }
    public Name? BrandName { get; }

    public ProductFilteringInfo(Name? productTypeName, Name? brandName)
    {
        ProductTypeName = productTypeName;
        BrandName = brandName;
    }
}