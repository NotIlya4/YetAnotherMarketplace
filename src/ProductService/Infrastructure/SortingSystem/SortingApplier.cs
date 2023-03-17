using System.Linq.Expressions;
using System.Reflection;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.Repositories;

public class SortingApplier<TEntity> : ISortingApplier<TEntity>
{
    public IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, SortingInfo<TEntity> primarySorting,
        IEnumerable<SortingInfo<TEntity>>? secondarySortings = null)
    {
        MethodCallExpression expression = ApplyOrderBy(query, primarySorting);
        
        if (secondarySortings is not null)
        {
            foreach (var secondarySorting in secondarySortings)
            {
                expression = ApplyThenBy(expression, secondarySorting);
            }
        }

        return query.Provider.CreateQuery<TEntity>(expression);
    }

    private MethodCallExpression ApplyOrderBy(IQueryable<TEntity> query, SortingInfo<TEntity> sortingInfo)
    {
        string orderingMethodName = sortingInfo.SortingSide == SortingSide.Asc
            ? nameof(Queryable.OrderBy)
            : nameof(Queryable.OrderByDescending);
        
        PropertyInfo sortingProperty = typeof(TEntity).GetProperty(sortingInfo.PropertyName.Value)!;
        
        Type[] queryableGenericTypes =
        {
            typeof(TEntity),
            sortingProperty.PropertyType
        };

        Expression queryAsExpression = query.Expression;
        
        return Expression.Call(
            typeof(Queryable), 
            orderingMethodName,
            queryableGenericTypes, 
            queryAsExpression,
            GetPropertyLambda(sortingInfo.PropertyName));
    }

    private MethodCallExpression ApplyThenBy(MethodCallExpression parent, SortingInfo<TEntity> sortingInfo)
    {
        string queryableMethodName = sortingInfo.SortingSide == SortingSide.Asc
            ? nameof(Queryable.ThenBy)
            : nameof(Queryable.ThenByDescending);
        
        PropertyInfo sortingProperty = typeof(TEntity).GetProperty(sortingInfo.PropertyName.Value)!;

        Type[] queryableGenericTypes =
        {
            typeof(TEntity),
            sortingProperty.PropertyType
        };
        
        return Expression.Call(
            typeof(Queryable),
            queryableMethodName,
            queryableGenericTypes,
            parent,
            GetPropertyLambda(sortingInfo.PropertyName));
    }

    private LambdaExpression GetPropertyLambda(PropertyName<TEntity> propertyName)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "entity");
        PropertyInfo sortingProperty = typeof(TEntity).GetProperty(propertyName.Value)!;
        Expression getPropertyFromEntity = Expression.MakeMemberAccess(parameter, sortingProperty);
        return Expression.Lambda(getPropertyFromEntity, parameter);
    }
}