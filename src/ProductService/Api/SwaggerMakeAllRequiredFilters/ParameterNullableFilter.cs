using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.SwaggerMakeAllRequiredFilters;

public class ParameterNullableFilter : IParameterFilter
{
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        parameter.Required = true;
    }
}