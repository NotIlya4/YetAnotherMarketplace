using Domain.Entities;

namespace Api.Controllers.BrandsControllers.Dtos;

public record BrandView
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Uri Website { get; set; }

    public static BrandView FromGetBrandDto(Brand brandDto)
    {
        return new BrandView()
        {
            Id = brandDto.Id,
            Name = brandDto.Name.Value,
            Website = brandDto.Website
        };
    }
}