using Domain.Entities.Brand;
using Domain.Entities.Product;

namespace Infrastructure.ProductService.Dtos;

public class CreateProductDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required string ProductType { get; set; }
    public required string BrandName { get; set; }

    public Product ToDomain(ProductId productId, Brand brand)
    {
        return new Product(
            id: productId,
            name: Name,
            description: Description,
            price: Price,
            pictureUrl: new Uri(PictureUrl),
            productType: ProductType,
            brand: brand);
    }
}