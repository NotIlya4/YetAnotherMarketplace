using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.EnrichersInterfaces;

public interface ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema);
}