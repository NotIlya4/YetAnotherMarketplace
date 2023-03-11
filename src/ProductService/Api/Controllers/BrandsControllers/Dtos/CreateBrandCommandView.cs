using Domain.Primitives;
using Infrastructure.Services.BrandService;

namespace Api.Controllers.BrandsControllers.Dtos;

public readonly struct CreateBrandCommandView
{
    public required string Name { get; init; }
    public required Uri Website { get; init; }

    public CreateBrandDto ToCreateBrandDto()
    {
        return new CreateBrandDto()
        {
            Name = new NotNullString(Name),
            Website = Website
        };
    }
}