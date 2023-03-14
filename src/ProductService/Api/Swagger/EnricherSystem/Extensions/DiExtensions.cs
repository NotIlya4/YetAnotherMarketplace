using System.Reflection;
using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Api.Swagger.EnricherSystem.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger.EnricherSystem.Extensions;

public static class DiExtensions
{
    public static void AddAllEnrichersInAssembly(this IServiceCollection serviceCollection,
        IEnumerable<Assembly> assemblies)
    {
        List<Type> enricherImplementations = assemblies.SelectMany(assembly =>
            assembly.GetTypes()
                .Where(type =>
                    type.IsAssignableTo(typeof(ISchemaEnricher)) || type.IsAssignableTo(typeof(IParameterEnricher)))
                .Where(type => !type.IsAbstract)
                .ToList()).ToList();

        foreach (var enricherImplementation in enricherImplementations)
        {
            serviceCollection.AddTransient(enricherImplementation);
        }
    }

    public static void AddEnricherFilters(this SwaggerGenOptions options)
    {
        options.ParameterFilter<ParameterEnricherFilter>();
        options.SchemaFilter<SchemaEnricherFilter>();
    }
}