using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.SwaggerEnrichers.InternalExceptionView;

public class InternalExceptionDetailAttribute : EnricherBaseAttribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Example = new OpenApiString("Something went wrong during execution...");
    }
}