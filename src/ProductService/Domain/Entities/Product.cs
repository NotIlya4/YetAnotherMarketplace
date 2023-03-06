using Domain.Primitives;

namespace Domain.Entities;

public class Product
{
    public Product(Guid id, NotNullString name, NotNullString description, Price price, Uri pictureUrl, ProductType productType, Brand brand)
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
    }

    public Guid Id { get; set; }
    public NotNullString Name { get; set; }
    public NotNullString Description { get; set; }
    public Price Price { get; set; }
    public Uri PictureUrl { get; set; }
    public ProductType ProductType { get; set; }
    public Brand Brand { get; set; }
}