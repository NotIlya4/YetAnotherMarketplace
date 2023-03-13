using Api.Swagger.Enrichers.EnrichersInterfaces;

namespace Api.Swagger.Enrichers.Attributes;

public class SwaggerParameterEnricherAttribute : Attribute
{
    public Type Enricher { get; set; }

    public SwaggerParameterEnricherAttribute(Type enricher)
    {
        enricher.IsAssignableTo(typeof(IParameterEnricher));
        Enricher = enricher;
    }
}