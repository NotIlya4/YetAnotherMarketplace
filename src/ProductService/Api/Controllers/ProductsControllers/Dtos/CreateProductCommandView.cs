using Domain.Primitives;
using Infrastructure.Services.ProductService;

namespace Api.Controllers.ProductsControllers.Dtos;

public record CreateProductCommandView
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required Uri PictureUrl { get; set; }
    public required string ProductType { get; set; }
    public required string BrandName { get; set; }
    
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