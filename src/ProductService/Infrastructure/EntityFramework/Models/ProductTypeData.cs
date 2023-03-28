using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.EntityFramework.Models;

public class ProductTypeData
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    public ProductType ToDomain()
    {
        return new ProductType(
            id: new Guid(Id),
            name: new Name(Name));
    }

    public static ProductTypeData FromDomain(ProductType productType)
    {
        return new ProductTypeData()
        {
            Id = productType.Id.ToString(),
            Name = productType.Name.Value
        };
    }

    public static List<ProductTypeData> FromDomain(IEnumerable<ProductType> productTypes)
    {
        return productTypes.Select(FromDomain).ToList();
    }
}