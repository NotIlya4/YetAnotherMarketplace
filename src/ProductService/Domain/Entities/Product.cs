using Domain.Interfaces;
using Domain.Primitives;

namespace Domain.Entities;

public record Product : IEntityComparable<Product>
{
    public Guid Id { get; }
    public Name Name { get; }
    public Description Description { get; }
    public Price Price { get; }
    public Uri PictureUrl { get; }
    public Name ProductType { get; }
    public Name Brand { get; }

    public Product(Guid id, Name name, Description description, Price price, Uri pictureUrl, Name productType, Name brand)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductType = productType;
        Brand = brand;
    }

    public bool EqualId(Product entity)
    {
        return Id.Equals(entity.Id);
    }
}