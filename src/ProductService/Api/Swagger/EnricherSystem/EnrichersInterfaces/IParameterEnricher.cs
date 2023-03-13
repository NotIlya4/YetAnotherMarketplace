using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.EnrichersInterfaces;

public interface IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter);
}