using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.NullableSystem;

public class SchemaNullableFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        ApplyNullableWhenProperty(schema, context);
        ApplyNullableWhenParameter(schema, context);
        ApplyNullableWhenType(schema, context);
    }

    private void ApplyNullableWhenProperty(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.MemberInfo is null) return;
        schema.Nullable = context.MemberInfo.GetCustomAttribute<SwaggerNullableAttribute>() is not null;
    }

    private void ApplyNullableWhenParameter(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.ParameterInfo is null) return;
        schema.Nullable = context.ParameterInfo.GetCustomAttribute<SwaggerNullableAttribute>() is not null;
    }
    
    private void ApplyNullableWhenType(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type is null) return;
        schema.Nullable = context.Type.GetCustomAttribute<SwaggerNullableAttribute>() is not null;
    }
}