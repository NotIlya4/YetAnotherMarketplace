using Api.Swagger.Enrichers.Brand;
using Domain.Primitives;
using Infrastructure.Services.BrandService;

namespace Api.Controllers.BrandsControllers.Views;

public class CreateBrandCommandView
{
    [BrandName]
    public required string Name { get; init; }
    [BrandWebsite]
    public required Uri Website { get; init; }

    public CreateBrandCommand ToCreateBrandDto()
    {
        return new CreateBrandCommand()
        {
            Name = new Name(Name),
            Website = Website
        };
    }
}