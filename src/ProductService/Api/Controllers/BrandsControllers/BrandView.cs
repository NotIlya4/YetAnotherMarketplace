using Domain.Entities;

namespace Api.Controllers.BrandsControllers;

public class BrandView
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    public static BrandView FromDomain(Brand brand)
    {
        return new BrandView()
        {
            Id = brand.Id.ToString(),
            Name = brand.Name.Value
        };
    }
}