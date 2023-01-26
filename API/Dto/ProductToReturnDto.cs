using Core.Entities;

namespace API.Dto;

public class ProductToReturnDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required string ProductType { get; set; }
    public required string ProductBrand { get; set; }
}