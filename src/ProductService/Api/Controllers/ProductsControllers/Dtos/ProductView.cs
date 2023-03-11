using Domain.Entities;

namespace Api.Controllers.ProductsControllers.Dtos;

public class ProductView
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    public required Uri PictureUrl { get; init; }
    public required string ProductType { get; init; }
    public required string BrandName { get; init; }
    public required Uri BrandWebsite { get; init; }

    public static ProductView FromGetProductDto(Product product)
    {
        return new ProductView()
        {
            Id = product.Id,
            Name = product.Name.Value,
            Description = product.Description.Value,
            Price = product.Price.Value,
            PictureUrl = product.PictureUrl,
            ProductType = product.ProductType.ToString(),
            BrandName = product.Brand.Name.Value,
            BrandWebsite = product.Brand.Website
        };
    }

    public static List<ProductView> FromGetProductDto(IEnumerable<Product> product)
    {
        return product.Select(FromGetProductDto).ToList();
    }
}