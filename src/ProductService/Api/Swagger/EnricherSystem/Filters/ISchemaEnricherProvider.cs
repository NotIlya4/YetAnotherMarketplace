using System.Reflection;
using Api.Swagger.EnricherSystem.CreateOwnEnrichers;

namespace Api.Swagger.EnricherSystem.Filters;

public interface ISchemaEnricherProvider
{
    public ISchemaEnricher? GetSchemaEnricher(ICustomAttributeProvider? attributeProvider);
}