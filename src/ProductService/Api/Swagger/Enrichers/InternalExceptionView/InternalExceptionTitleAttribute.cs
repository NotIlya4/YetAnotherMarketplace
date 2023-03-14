using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.InternalExceptionView;

public class InternalExceptionTitleAttribute : BaseAttribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Example = new OpenApiString("Internal exception");
    }
}