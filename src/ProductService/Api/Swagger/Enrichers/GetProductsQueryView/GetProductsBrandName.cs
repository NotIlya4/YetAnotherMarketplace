using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.GetProductsQueryView;

public class GetProductsBrandName : Attribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Required = false;
    }
}