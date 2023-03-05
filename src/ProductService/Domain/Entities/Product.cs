using Domain.Primitives;

namespace Domain.Entities;

public class Product
{
    public Product(Guid id, NotNullString name, NotNullString description, decimal price, Uri pictureUrl, NotNullString productType, Brand brand)
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
    public decimal Price { get; set; }
    public Uri PictureUrl { get; set; }
    public NotNullString ProductType { get; set; }
    public Brand Brand { get; set; }
}