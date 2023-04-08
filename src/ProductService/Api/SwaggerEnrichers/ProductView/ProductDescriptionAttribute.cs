using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.SwaggerEnrichers.ProductView;

public class ProductDescriptionAttribute : EnricherBaseAttribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Example = new OpenApiString("Wireless earbuds with charging case");
    }
}