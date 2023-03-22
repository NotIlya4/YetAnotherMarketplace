using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.EntityFramework.Models;

public class ProductData
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required ProductTypeData ProductType { get; set; }
    public required BrandData Brand { get; set; }

    public Product ToDomain()
    {
        return new Product(
            id: new Guid(Id),
            name: new Name(Name),
            description: new Description(Description),
            price: new Price(Price),
            pictureUrl: new Uri(PictureUrl),
            productType: ProductType.ToDomain(),
            brand: Brand.ToDomain());
    }

    public static List<Product> ToDomain(IEnumerable<ProductData> productDatas)
    {
        return productDatas.Select(pd => pd.ToDomain()).ToList();
    }

    public static ProductData FromDomain(Product product)
    {
        return new ProductData()
        {
            Id = product.Id.ToString(),
            Name = product.Name.Value,
            Description = product.Description.Value,
            Price = product.Price.Value,
            PictureUrl = product.PictureUrl.ToString(),
            ProductType = ProductTypeData.FromDomain(product.ProductType),
            Brand = BrandData.FromDomain(product.Brand)
        };
    }
}