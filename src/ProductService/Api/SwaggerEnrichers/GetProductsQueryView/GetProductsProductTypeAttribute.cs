using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.SwaggerEnrichers.GetProductsQueryView;

public class GetProductsProductTypeAttribute : Attribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Required = false;
    }
}