using Domain.Entities.Brand;

namespace Infrastructure.BrandService.Dtos;

public class GetBrandDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Website { get; set; }

    public static GetBrandDto FromDomain(Brand brand)
    {
        return new GetBrandDto()
        {
            Id = brand.Id.ToString(),
            Name = brand.Name,
            Website = brand.Website.ToString()
        };
    }
}