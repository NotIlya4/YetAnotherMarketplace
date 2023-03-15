using Domain.Primitives;

namespace Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Name Name { get; set; }
    public Description Description { get; set; }
    public Price Price { get; set; }
    public Uri PictureUrl { get; set; }
    public ProductType ProductType { get; set; }
    public Brand Brand { get; set; }

    public Product(Guid id, Name name, Description description, Price price, Uri pictureUrl, ProductType productType, Brand brand)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductType = productType;
        Brand = brand;
    }

    private Product()
    {
        PictureUrl = null!;
        Brand = null!;
        ProductType = null!;
    }
}