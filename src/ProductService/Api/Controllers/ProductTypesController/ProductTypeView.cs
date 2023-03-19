using Domain.Entities;

namespace Api.Controllers.ProductTypesController;

public class ProductTypeView
{
    public required string Id { get; init; }
    public required string Name { get; init; }

    public static ProductTypeView FromDomain(ProductType productType)
    {
        return new ProductTypeView()
        {
            Id = productType.Id.ToString(),
            Name = productType.Name.Value
        };
    }
}