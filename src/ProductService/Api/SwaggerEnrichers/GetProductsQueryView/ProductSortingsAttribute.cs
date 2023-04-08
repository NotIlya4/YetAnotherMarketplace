using Infrastructure.SortingSystem.Product;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.SwaggerEnrichers.GetProductsQueryView;

public class ProductSortingsAttribute : EnricherBaseAttribute, IParameterEnricher
{
    private readonly SortingEnricher _sortingEnricher;

    public ProductSortingsAttribute()
    {
        _sortingEnricher = new SortingEnricher(Enum.GetNames<ProductSortingProperty>());
    }
    
    public void Enrich(OpenApiParameter parameter)
    {
        _sortingEnricher.Enrich(parameter);
        parameter.Required = false;
    }
}