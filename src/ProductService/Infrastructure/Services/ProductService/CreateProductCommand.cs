using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.ProductService;

public class CreateProductCommand
{
    public required Name Name { get; set; }
    public required Description Description { get; set; }
    public required Price Price { get; set; }
    public required Uri PictureUrl { get; set; }
    public required Name ProductType { get; set; }
    public required Name BrandName { get; set; }

    public Product ToDomain(Guid productId, Brand brand, ProductType productType)
    {
        return new Product(
            id: productId,
            name: Name,
            description: Description,
            price: Price,
            pictureUrl: PictureUrl,
            productType: productType,
            brand: brand);
    }
}