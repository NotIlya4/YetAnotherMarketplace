using System.Reflection;
using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.EnricherSystem.Filters;

public class ParameterEnricherFilter : IParameterFilter
{
    private readonly IParameterEnricherProvider _enricherProvider;

    public ParameterEnricherFilter()
    {
        _enricherProvider = new EnricherProvider(new AttributeExtractor());
    }
    
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        Enrich(parameter, context.PropertyInfo);
        Enrich(parameter, context.ParameterInfo);
    }

    private void Enrich(OpenApiParameter parameter, ICustomAttributeProvider? attributeProvider)
    {
        IParameterEnricher? enricher = _enricherProvider.GetParameterEnricher(attributeProvider);

        enricher?.Enrich(parameter);
    }
}