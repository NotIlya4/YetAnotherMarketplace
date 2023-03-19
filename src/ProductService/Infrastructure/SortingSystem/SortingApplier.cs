using System.Linq.Expressions;
using System.Reflection;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.SortingSystem;

public class SortingApplier
{
    private readonly PropertyReflections _propertyReflections;

    public SortingApplier(PropertyReflections propertyReflections)
    {
        _propertyReflections = propertyReflections;
    }
    
    public IQueryable<TEntity> ApplySorting<TEntity>(IQueryable<TEntity> query, ISortingInfo primarySorting,
        IEnumerable<ISortingInfo>? secondarySortings = null)
    {
        MethodCallExpression expression = ApplyOrderBy(query, primarySorting);
        
        if (secondarySortings is not null)
        {
            foreach (var secondarySorting in secondarySortings)
            {
                expression = ApplyThenBy<TEntity>(expression, secondarySorting);
            }
        }

        return query.Provider.CreateQuery<TEntity>(expression);
    }

    private MethodCallExpression ApplyOrderBy<TClass>(IQueryable<TClass> query, ISortingInfo sortingInfo)
    {
        string queryableMethodName = sortingInfo.SortingSide == SortingSide.Asc
            ? nameof(Queryable.OrderBy)
            : nameof(Queryable.OrderByDescending);

        return ApplyQueryableMethod<TClass>(query.Expression, queryableMethodName, sortingInfo.PropertyName);
    }

    private MethodCallExpression ApplyThenBy<TClass>(MethodCallExpression parent, ISortingInfo sortingInfo)
    {
        string queryableMethodName = sortingInfo.SortingSide == SortingSide.Asc
            ? nameof(Queryable.ThenBy)
            : nameof(Queryable.ThenByDescending);

        return ApplyQueryableMethod<TClass>(parent, queryableMethodName, sortingInfo.PropertyName);
    }

    private MethodCallExpression ApplyQueryableMethod<TClass>(Expression queryExpression, string queryableMethodName, string propertyName)
    {
        PropertyInfo sortingProperty = _propertyReflections.GetProperty(typeof(TClass), propertyName);

        Type[] queryableGenericTypes =
        {
            typeof(TClass),
            sortingProperty.PropertyType
        };
        
        return Expression.Call(
            typeof(Queryable),
            queryableMethodName,
            queryableGenericTypes,
            queryExpression,
            _propertyReflections.GetPropertyLambda(typeof(TClass), propertyName));
    }
}