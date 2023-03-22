using Api.Swagger.Enrichers.Product;
using Domain.Primitives;
using Infrastructure.Services.ProductService;

namespace Api.Controllers.ProductsControllers.Views;

public class CreateProductCommandView
{
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
    
    public CreateProductCommand ToCreateProductDto()
    {
        return new CreateProductCommand()
        {
            Name = new Name(Name),
            Description = new Description(Description),
            Price = new Price(Price),
            PictureUrl = PictureUrl,
            ProductTypeName = new Name(ProductType),
            BrandName = new Name(Brand)
        };
    }
}