namespace Core.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public ProductType? ProductType { get; set; }
    public required int ProductTypeId { get; set; }
    public ProductBrand? ProductBrand { get; set; }
    public int ProductBrandId { get; set; }
}