using Api.Swagger.Enrichers.Product;
using Domain.Primitives;
using Infrastructure.Services.ProductService;

namespace Api.Controllers.ProductsControllers.Views;

public class CreateProductCommandView
{
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
    
    public CreateProductCommand ToCreateProductDto()
    {
        return new CreateProductCommand()
        {
            Name = new Name(Name),
            Description = new Description(Description),
            Price = new Price(Price),
            PictureUrl = PictureUrl,
            ProductTypeName = new Name(ProductType),
            BrandName = new Name(BrandName)
        };
    }
}