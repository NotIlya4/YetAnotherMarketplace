using Domain.Primitives;
using Infrastructure.Services.BrandService;

namespace Api.Controllers.BrandsControllers.Dtos;

public record CreateBrandCommandView
{
    public required string Name { get; set; }
    public required Uri Website { get; set; }

    public CreateBrandDto ToCreateBrandDto()
    {
        return new CreateBrandDto()
        {
            Name = new NotNullString(Name),
            Website = Website
        };
    }
}