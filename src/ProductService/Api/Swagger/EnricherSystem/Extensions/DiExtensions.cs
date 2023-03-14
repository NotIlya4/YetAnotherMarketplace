using System.Reflection;
using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Api.Swagger.EnricherSystem.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.EnricherSystem.Extensions;

public static class DiExtensions
{
    public static void AddEnricherFilters(this SwaggerGenOptions options)
    {
        options.ParameterFilter<ParameterEnricherFilter>();
        options.SchemaFilter<SchemaEnricherFilter>();
    }
}