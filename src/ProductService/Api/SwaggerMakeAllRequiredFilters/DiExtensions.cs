using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.SwaggerMakeAllRequiredFilters;

public static class DiExtensions
{
    public static void AddRequiredFilters(this SwaggerGenOptions options)
    {
        options.ParameterFilter<ParameterNullableFilter>();
        options.SchemaFilter<SchemaNullableFilter>();
    }
}