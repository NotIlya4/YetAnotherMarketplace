using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers.Product;

public class ProductPriceAttribute : BaseAttribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Example = new OpenApiFloat(149.99f);
    }
}