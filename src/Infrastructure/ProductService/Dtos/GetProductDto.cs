using Domain.Entities.Product;

namespace Infrastructure.ProductService.Dtos;

public class GetProductDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required string ProductType { get; set; }
    public required string BrandName { get; set; }
    public required string BrandWebsite { get; set; }

    public static GetProductDto FromDomainModel(Product domainModel)
    {
        return new GetProductDto()
        {
            Id = domainModel.Id.ToString(),
            Name = domainModel.Name,
            Description = domainModel.Description,
            Price = domainModel.Price,
            PictureUrl =  domainModel.PictureUrl.ToString(),
            ProductType = domainModel.ProductType,
            BrandName = domainModel.Brand.Name,
            BrandWebsite = domainModel.Brand.Website.ToString()
        };
    }
}