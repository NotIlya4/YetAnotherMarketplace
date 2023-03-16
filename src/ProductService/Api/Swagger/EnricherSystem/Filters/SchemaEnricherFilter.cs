using System.Reflection;
using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.EnricherSystem.Filters;

public class SchemaEnricherFilter : ISchemaFilter
{
    private readonly ISchemaEnricherProvider _enricherProvider = new EnricherProvider();
    
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        Enrich(schema, context.MemberInfo);
        Enrich(schema, context.ParameterInfo);
        Enrich(schema, context.Type);
    }

    private void Enrich(OpenApiSchema schema, ICustomAttributeProvider? attributeProvider)
    {
        ISchemaEnricher? enricher = _enricherProvider.GetSchemaEnricher(attributeProvider);

        enricher?.Enrich(schema);
    }
}