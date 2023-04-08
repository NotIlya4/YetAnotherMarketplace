using Domain.Interfaces;

namespace Infrastructure.EntityFramework.Models;

public class ProductTypeData : IEntityComparable<ProductTypeData>
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    public bool EqualId(ProductTypeData entity)
    {
        return Id == entity.Id;
    }
}