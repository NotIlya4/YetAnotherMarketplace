using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.SwaggerEnrichers.GetProductsQueryView;

public class GetProductsBrandAttribute : Attribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Required = false;
    }
}