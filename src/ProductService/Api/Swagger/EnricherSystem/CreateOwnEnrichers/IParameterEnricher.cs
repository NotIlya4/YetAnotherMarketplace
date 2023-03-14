using Microsoft.OpenApi.Models;

namespace Api.Swagger.EnricherSystem.CreateOwnEnrichers;

public interface IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter);
}