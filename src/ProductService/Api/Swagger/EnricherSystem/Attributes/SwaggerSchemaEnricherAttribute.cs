using Api.Swagger.Enrichers.EnrichersInterfaces;

namespace Api.Swagger.Enrichers.Attributes;

public class SwaggerSchemaEnricherAttribute : Attribute
{
    public Type Enricher { get; set; }

    public SwaggerSchemaEnricherAttribute(Type enricher)
    {
        enricher.IsAssignableTo(typeof(ISchemaEnricher));
        Enricher = enricher;
    }
}