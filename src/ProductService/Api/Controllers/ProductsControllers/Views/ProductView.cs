using Api.Swagger.Enrichers.Product;
using Domain.Entities;

namespace Api.Controllers.ProductsControllers.Views;

public class ProductView
{
    public required Guid Id { get; init; }
    [ProductName]
    public required string Name { get; init; }
    [ProductDescription]
    public required string Description { get; init; }
    [ProductPrice]
    public required decimal Price { get; init; }
    [ProductPictureUrl]
    public required Uri PictureUrl { get; init; }
    [ProductType]
    public required string ProductType { get; init; }
    [ProductBrandName]
    public required string BrandName { get; init; }
    [ProductBrandWebsite]
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