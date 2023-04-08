using Api.SwaggerEnrichers.ProductStrictFilterView;

namespace Api.Controllers.ProductsControllers.Views;

public record ProductStrictFilterView
{
    [ProductStrictFilterPropertyName]
    public required string PropertyName { get; init; }
    public required string Value { get; init; }
}