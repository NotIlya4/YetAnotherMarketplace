using Domain.Primitives;

namespace Domain.Entities.Product;

public class Product : BaseModel<ProductId>
{
    public Product(ProductId id, string name, string description, decimal price, Uri pictureUrl, string productType, Brand.Brand brand) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductType = productType;
        Brand = brand;
    }

    private Product(): base(null!)
    {
        Name = null!;
        Description = null!;
        PictureUrl = null!;
        ProductType = null!;
        Brand = null!;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Uri PictureUrl { get; set; }
    public string ProductType { get; set; }
    public Brand.Brand Brand { get; set; }
}