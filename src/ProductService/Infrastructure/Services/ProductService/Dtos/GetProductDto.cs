using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.ProductService.Dtos;

public record GetProductDto
{
    public required Guid Id { get; set; }
    public required NotNullString Name { get; set; }
    public required NotNullString Description { get; set; }
    public required decimal Price { get; set; }
    public required Uri PictureUrl { get; set; }
    public required NotNullString ProductType { get; set; }
    public required NotNullString BrandName { get; set; }
    public required Uri BrandWebsite { get; set; }

    public static GetProductDto FromDomainModel(Product domainModel)
    {
        return new GetProductDto()
        {
            Id = domainModel.Id,
            Name = domainModel.Name,
            Description = domainModel.Description,
            Price = domainModel.Price,
            PictureUrl =  domainModel.PictureUrl,
            ProductType = domainModel.ProductType,
            BrandName = domainModel.Brand.Name,
            BrandWebsite = domainModel.Brand.Website
        };
    }
}