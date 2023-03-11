using Domain.Primitives;
using Infrastructure.Services.ProductService;

namespace Api.Controllers.ProductsControllers.Dtos;

public class CreateProductCommandView
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    public required Uri PictureUrl { get; init; }
    public required string ProductType { get; init; }
    public required string BrandName { get; init; }
    
    public CreateProductCommand ToCreateProductDto()
    {
        return new CreateProductCommand()
        {
            Name = new NotNullString(Name),
            Description = new NotNullString(Description),
            Price = new Price(Price),
            PictureUrl = PictureUrl,
            ProductType = Enum.Parse<ProductType>(ProductType),
            BrandName = new NotNullString(BrandName)
        };
    }
}