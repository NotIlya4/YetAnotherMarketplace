namespace Core.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required ProductType ProductType { get; set; }
    public required int ProductTypeId { get; set; }
    public required ProductBrand ProductBrand { get; set; }
    public required int ProductBrandId { get; set; }
}