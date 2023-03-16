using System.Reflection;

namespace Api.Swagger.EnricherSystem.Filters;

public class AttributeExtractor
{
    private List<TAttribute> GetAttributesAssignableToGeneric<TAttribute>(ICustomAttributeProvider attributeProvider) 
        where TAttribute : class
    {
        return attributeProvider
            .GetCustomAttributes(false)
            .Where(a => a.GetType().IsAssignableTo(typeof(TAttribute)))
            .Select(a => (TAttribute)a)
            .ToList();
    }
    
    public TAssignableTo? GetAttributeAssignableTo<TAssignableTo>(ICustomAttributeProvider attributeProvider) 
        where TAssignableTo : class
    {
        List<TAssignableTo> attributes = GetAttributesAssignableToGeneric<TAssignableTo>(attributeProvider);
        if (attributes.Count == 0) return null;

        return attributes[0];
    }
}