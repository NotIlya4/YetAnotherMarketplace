using Infrastructure.Services.BrandService.Dtos;

namespace Api.Controllers.BrandsControllers.Dtos;

public record GetBrandView
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Uri Website { get; set; }

    public static GetBrandView FromGetBrandDto(GetBrandDto getBrandDto)
    {
        return new GetBrandView()
        {
            Id = getBrandDto.Id,
            Name = getBrandDto.Name.Value,
            Website = getBrandDto.Website
        };
    }
}