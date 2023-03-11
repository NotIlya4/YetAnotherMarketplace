using Domain.Entities;

namespace Api.Controllers.BrandsControllers.Dtos;

public class BrandView
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required Uri Website { get; init; }

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