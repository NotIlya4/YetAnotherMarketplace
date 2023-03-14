using Api.Swagger.EnricherSystem.CreateOwnEnrichers;
using Infrastructure;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Swagger.Enrichers;

public class SortingEnricher : IParameterEnricher
{
    private readonly List<string> _availableSortings;

    public SortingEnricher(IEnumerable<string> availableSortingProperties)
    {
        availableSortingProperties = availableSortingProperties.Select(s => s.ToLower()).ToList();
        _availableSortings = ApplyPlusMinusToProperties(availableSortingProperties);
    }

    public void Enrich(OpenApiParameter schema)
    {
        schema.Description = $"Available sortings: {_availableSortings.ToReadableString()}";
        schema.Schema.Items.Default = new OpenApiString("");
    }

    public static List<string> ApplyPlusMinusToProperties(IEnumerable<string> properties)
    {
        return properties.SelectMany(s => new List<string>() { $"+{s}", $"-{s}" }).ToList();
    }
}