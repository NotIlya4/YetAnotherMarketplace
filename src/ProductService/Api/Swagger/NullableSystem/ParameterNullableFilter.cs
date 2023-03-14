using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.NullableSystem;

public class ParameterNullableFilter : IParameterFilter
{
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        ApplyNullableWhenProperty(parameter, context);
        ApplyNullableWhenParameter(parameter, context);
    }
    private void ApplyNullableWhenProperty(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (context.PropertyInfo is null) return;
        
        parameter.Required = !context.PropertyInfo.HasAttribute<SwaggerNullableAttribute>();
    }
    
    private void ApplyNullableWhenParameter(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (context.ParameterInfo is null) return;
        
        parameter.Required = context.ParameterInfo.GetCustomAttribute<SwaggerNullableAttribute>() is null;
    }
}