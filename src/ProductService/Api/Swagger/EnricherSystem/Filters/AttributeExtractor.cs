using System.Reflection;

namespace Api.Swagger.EnricherSystem.Filters;

public class AttributeExtractor
{
    public List<TAttribute> GetAttributesAssignableToGeneric<TAttribute>(ICustomAttributeProvider attributeProvider) 
        where TAttribute : class
    {
        return attributeProvider
            .GetCustomAttributes(false)
            .Where(a => a.GetType().IsAssignableTo(typeof(TAttribute)))
            .Select(a => (TAttribute)a)
            .ToList();
    }
    
    public TAttribute? GetAttributeAssignableToGeneric<TAttribute>(ICustomAttributeProvider attributeProvider) 
        where TAttribute : class
    {
        List<TAttribute> attributes = GetAttributesAssignableToGeneric<TAttribute>(attributeProvider);
        if (attributes.Count == 0) return null;

        return attributes[0];
    }
}