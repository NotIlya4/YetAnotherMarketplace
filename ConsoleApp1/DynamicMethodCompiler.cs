using System.Linq.Expressions;
using System.Reflection;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers;
using Infrastructure.ExceptionCatching.ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using ParameterExpression = System.Linq.Expressions.ParameterExpression;

namespace ConsoleApp1;

public class DynamicMethodCompiler
{
    #region Secret
    public static Func<Object, Object[], Object> CreateForNonVoidInstanceMethod(MethodInfo method) {
        ParameterExpression instanceParameter = Expression.Parameter(typeof(Object), "target");
        ParameterExpression argumentsParameter = Expression.Parameter(typeof(Object[]), "arguments");

        MethodCallExpression call = Expression.Call(
            Expression.Convert(instanceParameter, method.DeclaringType ?? throw new Exception()),
            method,
            CreateParameterExpressions(method, argumentsParameter));

        Expression<Func<Object, Object[], Object>> lambda = Expression.Lambda<Func<Object, Object[], Object>>(
            Expression.Convert(call, typeof(Object)),
            instanceParameter,
            argumentsParameter);

        return lambda.Compile();
    }

    private static Expression[] CreateParameterExpressions(MethodInfo method, Expression argumentsParameter) {
        return method.GetParameters().Select((parameter, index) =>
            Expression.Convert(
                Expression.ArrayIndex(argumentsParameter, Expression.Constant(index)), parameter.ParameterType)).Cast<Expression>().ToArray();
    }
    #endregion

    public static Func<object, Exception, BadResponse> CompileMapperMethod(MethodInfo methodInfo)
    {
        Type instanseType = methodInfo.DeclaringType ?? throw new Exception();
        Type argumentExceptionType = methodInfo.GetParameters()[0].ParameterType;
        
        ParameterExpression thisArgument = Expression.Parameter(typeof(object), "this");
        ParameterExpression passedException = Expression.Parameter(typeof(Exception), "arguments");

        MethodCallExpression call = Expression.Call(
            Expression.Convert(thisArgument, instanseType),
            methodInfo,
            Expression.Convert(passedException, argumentExceptionType));

        Expression<Func<Object, Exception, BadResponse>> delegateExpression = Expression.Lambda<Func<object, Exception, BadResponse>>(
            call,
            thisArgument,
            passedException);

        return delegateExpression.Compile();
    }
}