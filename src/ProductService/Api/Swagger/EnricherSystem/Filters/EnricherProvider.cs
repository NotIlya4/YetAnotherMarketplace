using System.Reflection;
using Api.Swagger.EnricherSystem.CreateOwnEnrichers;

namespace Api.Swagger.EnricherSystem.Filters;

public class EnricherProvider : ISchemaEnricherProvider, IParameterEnricherProvider
{
    private readonly AttributeExtractor _attributeExtractor;

    public EnricherProvider(AttributeExtractor attributeExtractor)
    {
        _attributeExtractor = attributeExtractor;
    }
    
    public IParameterEnricher? GetParameterEnricher(ICustomAttributeProvider? attributeProvider)
    {
        if (attributeProvider is null) return null;

        return _attributeExtractor.GetAttributeAssignableToGeneric<IParameterEnricher>(attributeProvider);
    }

    public ISchemaEnricher? GetSchemaEnricher(ICustomAttributeProvider? attributeProvider)
    {
        if (attributeProvider is null) return null;
        
        return _attributeExtractor.GetAttributeAssignableToGeneric<ISchemaEnricher>(attributeProvider);
    }
}