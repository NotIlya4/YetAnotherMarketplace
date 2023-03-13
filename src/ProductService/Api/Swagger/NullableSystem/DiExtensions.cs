using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.Nullable;

public static class DiExtensions
{
    public static void AddNullableFilters(this SwaggerGenOptions options)
    {
        options.ParameterFilter<ParameterNullableFilter>();
        options.SchemaFilter<SchemaNullableFilter>();
    }
}