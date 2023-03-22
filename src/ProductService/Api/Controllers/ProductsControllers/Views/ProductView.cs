using Api.Swagger.Enrichers.Product;
using Domain.Entities;

namespace Api.Controllers.ProductsControllers.Views;

public class ProductView
{
    public required Guid Id { get; set; }
    [ProductName]
    public required string Name { get; set; }
    [ProductDescription]
    public required string Description { get; set; }
    [ProductPrice]
    public required decimal Price { get; set; }
    [ProductPictureUrl]
    public required Uri PictureUrl { get; set; }
    [ProductType]
    public required string ProductType { get; set; }
    [ProductBrandName]
    public required string Brand { get; set; }

    public static ProductView FromProduct(Product product)
    {
        return new ProductView()
        {
            Id = product.Id,
            Name = product.Name.Value,
            Description = product.Description.Value,
            Price = product.Price.Value,
            PictureUrl = product.PictureUrl,
            ProductType = product.ProductType.Name.Value,
            Brand = product.Brand.Name.Value,
        };
    }

    public static List<ProductView> FromProducts(IEnumerable<Product> product)
    {
        return product.Select(FromProduct).ToList();
    }
}