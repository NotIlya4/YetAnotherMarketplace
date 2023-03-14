using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Infrastructure.SortingSystem.SortingInfoProviders;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.Product;

public class ProductSortingAttribute : BaseAttribute, IParameterEnricher
{
    private readonly SortingEnricher _sortingEnricher;

    public ProductSortingAttribute()
    {
        _sortingEnricher = new SortingEnricher(ProductSortingInfo.AvailableSortingProperties);
    }
    
    public void Enrich(OpenApiParameter parameter)
    {
        _sortingEnricher.Enrich(parameter);
    }
}