using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.EntityFramework.Models;

public class BrandData : IEntity<BrandData>
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    public Brand ToDomain()
    {
        return new Brand(
            id: new Guid(Id),
            name: new Name(Name));
    }

    public static BrandData FromDomain(Brand brand)
    {
        return new BrandData()
        {
            Id = brand.Id.ToString(),
            Name = brand.Name.Value
        };
    }

    public static List<BrandData> FromDomain(IEnumerable<Brand> brands)
    {
        return brands.Select(FromDomain).ToList();
    }

    public bool EqualId(BrandData entity)
    {
        return Id == entity.Id;
    }
}