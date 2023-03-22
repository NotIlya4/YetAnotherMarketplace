using Domain.Entities;

namespace Api.Controllers.ProductTypesController;

public class ProductTypeView
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    public static ProductTypeView FromDomain(ProductType productType)
    {
        return new ProductTypeView()
        {
            Id = productType.Id.ToString(),
            Name = productType.Name.Value
        };
    }
}