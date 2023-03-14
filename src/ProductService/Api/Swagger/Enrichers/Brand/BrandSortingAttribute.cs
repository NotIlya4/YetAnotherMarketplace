using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Infrastructure.SortingSystem.SortingInfoProviders;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.Brand;

public class BrandSortingAttribute : BaseAttribute, IParameterEnricher
{
    private readonly SortingEnricher _sortingEnricher;

    public BrandSortingAttribute()
    {
        _sortingEnricher = new SortingEnricher(BrandSortingInfo.AvailableSortingProperties);
    }

    public void Enrich(OpenApiParameter parameter)
    {
        _sortingEnricher.Enrich(parameter);
    }
}