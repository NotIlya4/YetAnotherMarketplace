using Domain.Primitives;
using Infrastructure.Services.ProductService.Dtos;

namespace Api.Controllers.ProductsControllers.Dtos;

public record CreateProductView
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required Uri PictureUrl { get; set; }
    public required string ProductType { get; set; }
    public required string BrandName { get; set; }
    
    public CreateProductDto ToCreateProductDto()
    {
        return new CreateProductDto()
        {
            Name = new NotNullString(Name),
            Description = new NotNullString(Description),
            Price = Price,
            PictureUrl = PictureUrl,
            ProductType = new NotNullString(ProductType),
            BrandName = new NotNullString(BrandName)
        };
    }
}