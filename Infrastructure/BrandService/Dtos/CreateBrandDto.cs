using Domain.Entities.Brand;

namespace Infrastructure.BrandService.Dtos;

public class CreateBrandDto
{
    public required string Name { get; set; }
    public required string Website { get; set; }

    public Brand ToDomain(BrandId brandId)
    {
        return new Brand(
            id: brandId,
            name: Name,
            website: new Uri(Website));
    }
}