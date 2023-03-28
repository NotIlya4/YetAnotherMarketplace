using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Infrastructure.SortingSystem;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.GetProductsQueryView;

public class ProductSortingsAttribute : BaseAttribute, IParameterEnricher
{
    private readonly SortingEnricher _sortingEnricher;

    public ProductSortingsAttribute()
    {
        _sortingEnricher = new SortingEnricher(ProductSortingInfo.AvailableSortingProperties);
    }
    
    public void Enrich(OpenApiParameter parameter)
    {
        _sortingEnricher.Enrich(parameter);
        parameter.Required = false;
    }
}