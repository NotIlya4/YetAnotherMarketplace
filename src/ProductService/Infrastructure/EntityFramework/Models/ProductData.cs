using Domain.Interfaces;

namespace Infrastructure.EntityFramework.Models;

public class ProductData : IEntityComparable<ProductData>
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required ProductTypeData ProductType { get; set; }
    public required BrandData Brand { get; set; }

    public bool EqualId(ProductData entity)
    {
        return Id == entity.Id;
    }
}