using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.ProductService;

public class CreateProductCommand
{
    public required NotNullString Name { get; set; }
    public required NotNullString Description { get; set; }
    public required Price Price { get; set; }
    public required Uri PictureUrl { get; set; }
    public required ProductType ProductType { get; set; }
    public required NotNullString BrandName { get; set; }

    public Product ToDomain(Guid productId, Brand brand)
    {
        return new Product(
            id: productId,
            name: Name,
            description: Description,
            price: Price,
            pictureUrl: PictureUrl,
            productType: ProductType,
            brand: brand);
    }
}