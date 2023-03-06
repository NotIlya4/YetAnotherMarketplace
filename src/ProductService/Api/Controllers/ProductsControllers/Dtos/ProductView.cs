using Domain.Entities;

namespace Api.Controllers.ProductsControllers.Dtos;

public record ProductView
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required Uri PictureUrl { get; set; }
    public required string ProductType { get; set; }
    public required string BrandName { get; set; }
    public required Uri BrandWebsite { get; set; }

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
}