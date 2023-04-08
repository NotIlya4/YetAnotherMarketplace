using Domain.Primitives;

namespace Infrastructure.ProductService;

public record CreateProductCommand
{
    public required Name Name { get; init; }
    public required Description Description { get; init; }
    public required Price Price { get; init; }
    public required Uri PictureUrl { get; init; }
    public required Name ProductType { get; init; }
    public required Name Brand { get; init; }
}