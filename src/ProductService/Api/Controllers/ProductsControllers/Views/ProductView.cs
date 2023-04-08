using Api.SwaggerEnrichers.ProductView;

namespace Api.Controllers.ProductsControllers.Views;

public record ProductView
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
    public required string Brand { get; init; }
}