using System.Reflection;
using Api.Swagger.Enrichers.Attributes;
using Api.Swagger.Enrichers.EnrichersInterfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.Enrichers.Filters;

public class SchemaEnricherFilter : ISchemaFilter
{
    private readonly IServiceProvider _serviceProvider;

    public SchemaEnricherFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        ApplyEnricherWhenProperty(schema, context);
        ApplyEnricherWhenParameter(schema, context);
        ApplyEnricherWhenType(schema, context);
    }

    private void ApplyEnricherWhenProperty(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.MemberInfo is null) return;
        
        var attribute = context.MemberInfo.GetCustomAttribute<SwaggerSchemaEnricherAttribute>();
        Enrich(schema, attribute);
    }
    
    private void ApplyEnricherWhenParameter(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.ParameterInfo is null) return;
        
        var attribute = context.ParameterInfo.GetCustomAttribute<SwaggerSchemaEnricherAttribute>();
        Enrich(schema, attribute);
    }
    
    private void ApplyEnricherWhenType(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type is null) return;
        
        var attribute = context.Type.GetCustomAttribute<SwaggerSchemaEnricherAttribute>();
        Enrich(schema, attribute);
    }

    private void Enrich(OpenApiSchema schema, SwaggerSchemaEnricherAttribute? attribute)
    {
        if (attribute is null) return;
        
        ISchemaEnricher enricher = (ISchemaEnricher?)_serviceProvider.GetService(attribute.Enricher) ??
                                   throw new NullReferenceException();
        enricher.Enrich(schema);
    }
}