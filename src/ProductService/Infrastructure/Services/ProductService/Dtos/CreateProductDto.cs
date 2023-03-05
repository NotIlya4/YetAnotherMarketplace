using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.ProductService.Dtos;

public record CreateProductDto
{
    public required NotNullString Name { get; set; }
    public required NotNullString Description { get; set; }
    public required decimal Price { get; set; }
    public required Uri PictureUrl { get; set; }
    public required NotNullString ProductType { get; set; }
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