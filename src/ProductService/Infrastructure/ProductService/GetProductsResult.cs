using Domain.Entities;

namespace Infrastructure.ProductService;

public record GetProductsResult
{
    public required List<Product> Products { get; init; }
    public required int Total { get; init; }
}