using Domain.Interfaces;

namespace Infrastructure.EntityFramework.Models;

public record BrandData : IEntityComparable<BrandData>
{
    public required string Id { get; init; }
    public required string Name { get; init; }

    public bool EqualId(BrandData entity)
    {
        return Id == entity.Id;
    }
}