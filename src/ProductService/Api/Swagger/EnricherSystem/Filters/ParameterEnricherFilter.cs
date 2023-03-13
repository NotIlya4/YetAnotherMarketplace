using System.Reflection;
using Api.Swagger.Enrichers.Attributes;
using Api.Swagger.Enrichers.EnrichersInterfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.Enrichers.Filters;

public class ParameterEnricherFilter : IParameterFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ParameterEnricherFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        ApplyEnricherWhenProperty(parameter, context);
        ApplyEnricherWhenParameter(parameter, context);
    }

    private void ApplyEnricherWhenProperty(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (context.PropertyInfo == null) return;
        
        var attribute = context.PropertyInfo.GetCustomAttribute<SwaggerParameterEnricherAttribute>();
        Enrich(parameter, attribute);
    }
    
    private void ApplyEnricherWhenParameter(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (context.ParameterInfo == null) return;
        
        var attribute = context.ParameterInfo.GetCustomAttribute<SwaggerParameterEnricherAttribute>();
        Enrich(parameter, attribute);
    }

    private void Enrich(OpenApiParameter parameter, SwaggerParameterEnricherAttribute? attribute)
    {
        if (attribute is null) return;

        IParameterEnricher enricher = (IParameterEnricher?)_serviceProvider.GetService(attribute.Enricher) ?? 
                                      throw new NullReferenceException();
        enricher.Enrich(parameter);
    }
}