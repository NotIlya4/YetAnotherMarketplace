using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.Product;

public class ProductPictureUrlAttribute : BaseAttribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Example = new OpenApiString("https://example.com/airpods.jpg");
    }
}