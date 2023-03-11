using System.Linq.Expressions;

namespace Infrastructure.PropertySystem;

public static class PropertyReflections
{
    public static Expression<Func<TClass, TReturn>> BuildPropertyLambdaFromName<TClass, TReturn>(PropertyName<TClass> propertyName)
    {
        ParameterExpression entityParameter = Expression.Parameter(typeof(TClass), typeof(TClass).Name.ToLower());

        MemberExpression callPropertyOnEntity = Expression.Property(entityParameter, propertyName.Value);
        
        UnaryExpression returnPropertyConvertedToObject = Expression.Convert(callPropertyOnEntity, typeof(TReturn));

        return Expression.Lambda<Func<TClass, TReturn>>(returnPropertyConvertedToObject, entityParameter);
    }

    public static string GetNameFromPropertyLambda<TClass, TReturn>(Expression<Func<TClass, TReturn>> lambda)
    {
        MemberExpression? memberExpression = null;

        if (lambda.Body is UnaryExpression unaryExpression)
        {
            memberExpression = (MemberExpression)unaryExpression.Operand;
        }
        
        if (lambda.Body is MemberExpression memExpression)
        {
            memberExpression = memExpression;
        }

        if (memberExpression is null)
        {
            throw new BadPropertyExpressionException(lambda);
        }

        return memberExpression.Member.Name;
    }
}