using Api.Swagger.Enrichers.Brand;
using Domain.Entities;

namespace Api.Controllers.BrandsControllers.Views;

public class BrandView
{
    public required Guid Id { get; init; }
    [BrandName]
    public required string Name { get; init; }
    [BrandWebsite]
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