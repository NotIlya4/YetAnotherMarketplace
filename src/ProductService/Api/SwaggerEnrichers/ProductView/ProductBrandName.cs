using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.SwaggerEnrichers.ProductView;

public class ProductBrandName : EnricherBaseAttribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Example = new OpenApiString("Apple");
    }
}