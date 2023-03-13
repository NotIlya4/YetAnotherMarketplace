using System.Reflection;
using Api.Swagger.Enrichers.EnrichersInterfaces;
using Api.Swagger.Enrichers.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.Enrichers.Extensions;

public static class DiExtensions
{
    public static void AddAllEnrichersInAssembly(this IServiceCollection serviceCollection,
        IEnumerable<Assembly> assemblies)
    {
        List<Type> enricherImplementations = assemblies.SelectMany(assembly =>
            assembly.GetTypes()
                .Where(type =>
                    type.IsAssignableTo(typeof(ISchemaEnricher)) || type.IsAssignableTo(typeof(IParameterEnricher)))
                .ToList()).ToList();

        foreach (var enricherImplementation in enricherImplementations)
        {
            serviceCollection.AddScoped(enricherImplementation);
        }
    }

    public static void AddEnricherFilters(this SwaggerGenOptions options)
    {
        options.ParameterFilter<ParameterEnricherFilter>();
        options.SchemaFilter<SchemaEnricherFilter>();
    }
}