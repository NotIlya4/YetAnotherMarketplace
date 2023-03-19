using System.Linq.Expressions;
using System.Reflection;
using Domain.Exceptions;

namespace Infrastructure.SortingSystem;

public class PropertyReflections
{
    public LambdaExpression GetPropertyLambda(Type type, string propertyName)
    {
        ParameterExpression parameter = Expression.Parameter(type, "entity");
        Expression getPropertyFromEntity = Expression.MakeMemberAccess(parameter, GetProperty(type, propertyName));
        return Expression.Lambda(getPropertyFromEntity, parameter);
    }

    public PropertyInfo GetProperty(Type type, string propertyName)
    {
        PropertyInfo? property = type.GetProperty(propertyName);

        if (property is null)
        {
            throw new ValidationException($"{type.Name} does not have property {propertyName}");
        }

        return property;
    }
}