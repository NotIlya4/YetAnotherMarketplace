using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Product;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.GetProductsQueryView;

public class ProductSortingsAttribute : BaseAttribute, IParameterEnricher
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