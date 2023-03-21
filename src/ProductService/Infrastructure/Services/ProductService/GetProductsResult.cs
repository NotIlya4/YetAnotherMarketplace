using Domain.Entities;

namespace Infrastructure.Services.ProductService;

public class GetProductsResult
{
    public required List<Product> Products { get; set; }
    public required int Total { get; set; }
}