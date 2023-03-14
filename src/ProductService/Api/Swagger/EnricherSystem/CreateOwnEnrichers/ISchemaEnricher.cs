using Microsoft.OpenApi.Models;

namespace Api.Swagger.EnricherSystem.CreateOwnEnrichers;

public interface ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema);
}