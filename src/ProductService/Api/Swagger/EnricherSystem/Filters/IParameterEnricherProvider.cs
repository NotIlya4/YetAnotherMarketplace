using System.Reflection;
using Api.Swagger.EnricherSystem.CreateOwnEnrichers;

namespace Api.Swagger.EnricherSystem.Filters;

public interface IParameterEnricherProvider
{
    public IParameterEnricher? GetParameterEnricher(ICustomAttributeProvider? attributeProvider);
}