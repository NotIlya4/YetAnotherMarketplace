using Infrastructure.Services.ProductService.Dtos;

namespace Api.Controllers.ProductsControllers.Dtos;

public record GetProductView
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required Uri PictureUrl { get; set; }
    public required string ProductType { get; set; }
    public required string BrandName { get; set; }
    public required Uri BrandWebsite { get; set; }

    public static GetProductView FromGetProductDto(GetProductDto getProductDto)
    {
        return new GetProductView()
        {
            Id = getProductDto.Id,
            Name = getProductDto.Name.Value,
            Description = getProductDto.Description.Value,
            Price = getProductDto.Price,
            PictureUrl = getProductDto.PictureUrl,
            ProductType = getProductDto.ProductType.Value,
            BrandName = getProductDto.BrandName.Value,
            BrandWebsite = getProductDto.BrandWebsite
        };
    }
}