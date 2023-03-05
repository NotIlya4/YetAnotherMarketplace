using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.BrandService.Dtos;

public record GetBrandDto
{
    public required Guid Id { get; set; }
    public required NotNullString Name { get; set; }
    public required Uri Website { get; set; }

    public static GetBrandDto FromDomain(Brand brand)
    {
        return new GetBrandDto()
        {
            Id = brand.Id,
            Name = brand.Name,
            Website = brand.Website
        };
    }
}